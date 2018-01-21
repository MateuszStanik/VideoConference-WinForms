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

namespace VideoConference
{
    public partial class Conference : Form
    {
        public string nick { get; set; }
        public string roomName { get; set; }

        const string SERVER_IP = "127.0.0.1";
        const string PORT = "4502";
        const string RECV_PORT = "7000";

        Welcome welcome;

        private System.Windows.Forms.Timer timer;

        XSocketClient c;
        #region WebCam API
        const short WM_CAP = 1024;
        const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        const int WM_CAP_EDIT_COPY = WM_CAP + 30;
        const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        const int WM_CAP_SET_SCALE = WM_CAP + 53;
        const int WS_CHILD = 1073741824;
        const int WS_VISIBLE = 268435456;
        const short SWP_NOMOVE = 2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 4;
        const short HWND_BOTTOM = 1;
        int iDevice = 0;
        int hHwnd;
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SendMessageA")]
        static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]
            object lParam);
        [System.Runtime.InteropServices.DllImport("user32", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [System.Runtime.InteropServices.DllImport("user32")]
        static extern bool DestroyWindow(int hndw);
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        [System.Runtime.InteropServices.DllImport("avicap32.dll")]
        static extern bool capGetDriverDescriptionA(short wDriver, string lpszName, int cbName, string lpszVer, int cbVer);
        private void OpenPreviewWindow()
        {
            int iHeight = CapturingPic.Height;
            int iWidth = CapturingPic.Width;
            // 
            //  Open Preview window in picturebox
            // 
            hHwnd = capCreateCaptureWindowA(iDevice.ToString(), (WS_VISIBLE | WS_CHILD), 0, 0, 640, 480, CapturingPic.Handle.ToInt32(), 0);
            // 
            //  Connect to device
            // 
            if (SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) == 1)
            {
                // 
                // Set the preview scale
                // 
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);
                // 
                // Set the preview rate in milliseconds
                // 
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);
                // 
                // Start previewing the image from the camera
                // 
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                // 
                //  Resize window to fit in picturebox
                // 
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, iWidth, iHeight, (SWP_NOMOVE | SWP_NOZORDER));
            }
            else
            {
                // 
                //  Error connecting to device close window
                //  
                DestroyWindow(hHwnd);
            }
        }
        private void ClosePreviewWindow()
        {
            // 
            //  Disconnect from device
            // 
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0);
            // 
            //  close window
            // 
            DestroyWindow(hHwnd);
        }

        #endregion

        internal System.Windows.Forms.PictureBox CapturingPic;

        public Conference(Welcome wlc)
        {
            InitializeComponent();

            welcome = wlc;

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
                c.Controller("generic").Invoke("joinRoom", new { nick=nick, roomName=roomName });
            };
            // custom events
            c.Controller("generic").On<string>("clientJoined", clientNick =>
            {
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText(clientNick + " joined room." + Environment.NewLine);
                    }));
            });
            c.Controller("generic").On<string>("clientLeft", clientNick =>
            {
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText(clientNick + " left room." + Environment.NewLine);
                    }));
            });
            c.Controller("generic").On<dynamic>("msgSent", data =>
            {
                this.Invoke(
                    new Action(() =>
                    {
                        string txt = data.author + ": " + data.content + Environment.NewLine;
                        Messages.AppendText(txt);
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
        }

        private void Conference_FormClosed(Object sender, FormClosedEventArgs e)
        {
            leaveRoom();
            welcome.Close();
        }

        TcpClient myclient;
        MemoryStream ms;
        NetworkStream myns;
        BinaryWriter mysw;
        Thread myth;
        TcpListener mytcpl;
        Socket mysocket;
        NetworkStream ns;

        //private void Start_Receiving_Video_Conference()
        //{
        //    try
        //    {
        //        IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
        //        //mytcpl = new TcpListener(ipaddress, 4502);
        //        // Open The Port
               
        //        mytcpl = new TcpListener(ipaddress, Int32.Parse(InputPort.Text));
        //        mytcpl.Start();						 // Start Listening on That Port
        //        //********TU SIE SYPIE************
        //        mysocket = mytcpl.AcceptSocket();		 // Accept Any Request From Client and Start a Session
        //        ns = new NetworkStream(mysocket);	 // Receives The Binary Data From Port

        //        ReceivedPic.Image = Image.FromStream(ns);
        //        mytcpl.Stop();							 // Close TCP Session

        //        if (mysocket.Connected == true)		     // Looping While Connected to Receive Another Message 
        //        {
        //            while (true)
        //            {
        //                Start_Receiving_Video_Conference();				 // Back to First Method
        //            }
        //        }
        //        myns.Flush();

        //    }
        //    catch (Exception ex) {
        //        MessageBox.Show(ex.Message, "Video Conference Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void Start_Sending_Video_Conference(string remote_IP, int port_number)
        //{
        //    try
        //    {
        //        ms = new MemoryStream();// Store it in Binary Array as Stream
        //        IDataObject data;
        //        Image bmap;
        //        //  Copy image to clipboard
        //        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0);

        //        //  Get image from clipboard and convert it to a bitmap
        //        data = Clipboard.GetDataObject();

        //        if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
        //        {
        //            bmap = ((Image)(data.GetData(typeof(System.Drawing.Bitmap))));
        //            bmap.Save(ms, ImageFormat.Bmp);
        //        }
        //        CapturingPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        byte[] arrImage = ms.GetBuffer();
        //        //myclient = new TcpClient(remote_IP, port_number);//Connecting with server
        //        myclient = new TcpClient(remote_IP, Int32.Parse(OutputPort.Text));
        //        myns = myclient.GetStream();
        //        mysw = new BinaryWriter(myns);
        //        mysw.Write(arrImage);//send the stream to above address
        //        ms.Flush();
        //        mysw.Flush();
        //        myns.Flush();
        //        ms.Close();
        //        mysw.Close();
        //        myns.Close();
        //        myclient.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Video Conference Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void SendVideoFrame()
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SendVideoFrame();
        }
        //private void CreateConnection_Click(object obj, EventArgs e)
        //{
        //    if ((OutputPort.Text.Length != 4) || (InputPort.Text.Length != 4))
        //    {
        //     MessageBox.Show("Nie podano właściwych portów.",
        //        "Uwaga!",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Exclamation,
        //        MessageBoxDefaultButton.Button1);
        //    }
        //    else{
        //        OpenPreviewWindow();
        //        myth = new Thread(new System.Threading.ThreadStart(Start_Receiving_Video_Conference)); // Start Thread Session
        //        myth.Start();
        //    }          
        //}

        private void showMe_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            OpenPreviewWindow();
        }

        private void hideMe_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            ClosePreviewWindow();
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
