using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSockets;
using AForge.Video;
using AForge.Video.DirectShow;
using XSockets.Core.Common.Socket.Event.Interface;
using DomainModels;

namespace VideoConference
{
    public struct GuestData
    {
        public int order { get; set; }
        public string nick { get; set; }
    }

    public partial class Conference : Form
    {
        const string SERVER_IP = "127.0.0.1";
        const string PORT = "4502";

        string nick { get; set; }
        string roomName { get; set; }
        int sid { get; set; }

        Dictionary<int, GuestData> sidToGuest;

        XSocketClient c;
        Welcome welcome;
        internal PictureBox SendingPic;
        Image sendingDefault;
        Image receivingDefault;

        FilterInfoCollection cams;
        VideoCaptureDevice cam;
        PictureBox[] receivePics;
        long nFrames;

        public Conference(Welcome wlc)
        {
            // gui
            InitializeComponent();
            hideMe.Enabled = false;
            receivePics = new System.Windows.Forms.PictureBox[5];
            receivePics[0] = ReceivedPic1;
            receivePics[1] = ReceivedPic2;
            receivePics[2] = ReceivedPic3;
            receivePics[3] = ReceivedPic4;
            welcome = wlc;
            sendingDefault = (Image)SendingPic.Image.Clone();
            receivingDefault = (Image)ReceivedPic1.Image.Clone();

            // guest data
            Random rnd = new Random();
            sid = rnd.Next();
            sidToGuest = new Dictionary<int, GuestData>();

            // camera 
            cams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cam = new VideoCaptureDevice(cams[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(newFrame);
            nFrames = 0;

            initializeXSocket();
        }

        public void initializeXSocket()
        {
            // connect
            c = new XSocketClient("ws://" + SERVER_IP + ":" + PORT, "http://localhost", "generic");
            // socket events
            c.OnConnected += (sender, eventArgs) => Messages.AppendText(Environment.NewLine + "Connected!" + Environment.NewLine);
            c.OnDisconnected += (sender, eventArgs) => Messages.AppendText(Environment.NewLine + "Disconnected!" + Environment.NewLine);
            // controller events
            c.Controller("generic").OnOpen += (sender, connectArgs) =>
            {
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText("Welcome to " + roomName + Environment.NewLine);
                    }));
                c.Controller("generic").Invoke("joinRoom", new { sid=sid, nick = nick, roomName = roomName });
            };
            // custom events
            c.Controller("generic").On<dynamic>("clientJoined", data =>
            {
                int dorder = data.order;
                string dnick = data.nick;
                int dsid = data.sid;
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText(dnick + " joined room." + Environment.NewLine);
                    }));
                sidToGuest.Add(dsid, new GuestData { order=dorder, nick=dnick });
            });
            c.Controller("generic").On<int>("clientLeft", clientSid =>
            {
                GuestData g = sidToGuest[clientSid];
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText(g.nick + " left room." + Environment.NewLine);
                    }));
                sidToGuest.Remove(clientSid);
            });
            c.Controller("generic").On<dynamic>("msgSent", data =>
            {
                string dcontent = data.content;
                int dsid = data.authorSid;
                GuestData g = sidToGuest[dsid];
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText(g.nick + ": " + dcontent + Environment.NewLine);
                    }));
            });
            c.Controller("generic").On<Messages[]>("fetchMessages", messages =>
            {
                this.Invoke(
                    new Action(() =>
                    {
                        foreach (Messages msg in messages) {
                            Messages.AppendText(msg.nick + ": " + msg.message + Environment.NewLine);
                        }
                    }));
            });
            c.Controller("generic").On<dynamic>("receiveFrame", data =>
            {
                int dsid = (int)data.sid;
                byte[] dframe = data.frame;
                bool hide = data.hide;
                GuestData g = sidToGuest[dsid];
                GuestData me = sidToGuest[sid];
                int order = g.order - (g.order > me.order ? 1 : 0);
                this.Invoke(
                    new Action(() =>
                    {
                        if (hide)
                        {
                            receivePics[order].Image = receivingDefault;
                        }
                        else
                        {
                            using (var stream = new MemoryStream(dframe))
                            {
                                Bitmap frame = new Bitmap(stream);
                                receivePics[order].Image = frame;
                            }
                        }
                    }));
            });
        }

        public void joinRoom(string n, string rn) {
            nick = n;
            roomName = rn;
            c.Open();
        }

        public void leaveRoom()
        {
            c.Controller("generic").Invoke("leaveRoom");
            c.Controller("generic").Close();
            //c.Disconnect();
        }

        private void Conference_FormClosed(Object sender, FormClosedEventArgs e)
        {
            leaveRoom();
            welcome.Close();
        }

        private void newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = eventArgs.Frame;
            Bitmap resized = new Bitmap(frame, new Size(SendingPic.Width, SendingPic.Height));
            SendingPic.Image = resized;
            nFrames++;
            sendFrame(frame);
        }

        public void sendFrame(Bitmap frame)
        {
            Bitmap resized = new Bitmap(frame, new Size(ReceivedPic1.Width, ReceivedPic1.Height)); // receive pic have equal dimensions
            using (var stream = new MemoryStream())
            {
                resized.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
                c.Controller("generic").Invoke("sendFrame", stream.ToArray());
            }
        }

        private void showMe_Click(object sender, EventArgs e)
        {
            if (showMe.Enabled)
            {
                hideMe.Enabled = true;
                showMe.Enabled = false;
                Messages.AppendText("You are now visible to others" + Environment.NewLine);
                cam.Start();
            }
        }

        private void hideMe_Click(object sender, EventArgs e)
        {
            if (hideMe.Enabled)
            {
                cam.Stop();
                hideMe.Enabled = false;
                showMe.Enabled = true;
                Messages.AppendText("You are now hidden" + Environment.NewLine);
                SendingPic.Image = sendingDefault;
                c.Controller("generic").Invoke("hideMe");
            }
        }

        private void SendMsg_Click(object sender, EventArgs e)
        {
            string content = "";
            content = Message.Text;
            c.Controller("generic").Invoke<string>("sendMsg", content);
            Message.Text = "";
            Message.Focus();
        }
    }
}
