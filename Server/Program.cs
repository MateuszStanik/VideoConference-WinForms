using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Common.Socket;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using System.Drawing;
using XSockets.Core.Common.Socket.Event.Interface;
using UnitOfWork.Concrete;
using Server.Models;
using DomainModels;

namespace Server
{
    class GuestData
    {
        public int sid { get; set; }
        public string nick { get; set; }
        public string roomName { get; set; }
        public int order { get; set; }
        public bool inRoom()
        {
            return order >= 0;
        }

        public GuestData()
        {
            sid = 0;
            nick = "";
            roomName = "";
            order = -1;
        }
    }

    class Room
    {
        const int MAX_GUESTS = 5;

        Dictionary<int, GuestData> guests;
        bool[] isGuest;

        public Room()
        {
            guests = new Dictionary<int, GuestData>();
            isGuest = new bool[MAX_GUESTS];
        }
        public void addGuest(GuestData g)  {
            int i = 0;
            while (i < MAX_GUESTS && isGuest[i]) {
                ++i;
            }
            g.order = i;
            guests.Add(g.sid, g);
            isGuest[i] = true;
        }

        public void removeGuest(int sid)
        {
            GuestData g = guests[sid];
            guests.Remove(sid);
            isGuest[g.order] = false;
            g.order = -1;
        }

        public GuestData[] getGuests()
        {
            return guests.Values.ToArray();
        }

        public bool isEmpty()
        {
            return guests.Count == 0;
        }

        
    }

    static class Rooms
    {
        static Dictionary<string, Room> rooms = new Dictionary<string, Room>();

        static public void addGuest(GuestData g)
        {
            Room room;
            if (rooms.ContainsKey(g.roomName))
            {
                room = rooms[g.roomName];
            }
            else
            {
                room = new Room();
                rooms.Add(g.roomName, room);
            }
            room.addGuest(g);
        }

        static public GuestData[] getGuests(string roomName)
        {
            return rooms[roomName].getGuests();
        }

        static public void removeGuest(GuestData g)
        {
            Room room = rooms[g.roomName];
            room.removeGuest(g.sid);
            if (room.isEmpty())
            {
                rooms.Remove(g.roomName);
            }
        }
    }

    public class Generic : XSocketController
    {
        private readonly EFDbContext db = new EFDbContext();

        GuestData g = new GuestData();

        public async void JoinRoom(dynamic data)
        {
            int sid = data.sid;
            string nick = data.nick;
            string roomName = data.roomName;
            g.sid = sid;
            g.nick = nick;
            g.roomName = roomName;
            Rooms.addGuest(g);
            await this.InvokeTo(c => c.g.inRoom() && c.g.roomName == g.roomName, new { sid=g.sid, nick=g.nick, order=g.order }, "clientJoined");
            // tell the new guest about other guests
            foreach (GuestData gd in Rooms.getGuests(g.roomName))
            {
                if (gd.sid != g.sid)
                {
                    await this.Invoke(new { sid = gd.sid, nick = gd.nick, order = gd.order }, "clientJoined");
                }
            }
            Messages[] messages = db.message.Where(m => m.roomName == g.roomName).ToArray();
            await this.Invoke(messages, "fetchMessages");
        }

        public async Task SendMsg(string content)
        {
            Messages message = new Messages();
            message.nick = g.nick;
            message.sid = g.sid;
            message.roomName = g.roomName;
            message.message = content;
            try
            {
                db.message.Add(message);
                db.SaveChanges();
            }
           catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            await this.InvokeTo(c => c.g.inRoom() && c.g.roomName == g.roomName, new { content = content, authorSid = g.sid }, "msgSent");
        }
        public async Task LeaveRoom()
        {
            Rooms.removeGuest(g);
            await this.InvokeTo(c => c.g.inRoom() && c.g.roomName == g.roomName, g.sid, "clientLeft");
        }

        public async Task sendFrame(IMessage message)
        {
            byte[] frame = message.Blob.ToArray();
            await this.InvokeTo(c => c.g.inRoom() && c.g.roomName == g.roomName && c.g.sid != g.sid, new { frame = frame, sid = g.sid, hide = false }, "receiveFrame");
        }

        public async Task hideMe()
        {
            await this.InvokeTo(c => c.g.inRoom() && c.g.roomName == g.roomName && c.g.sid != g.sid, new { frame = new byte[1], sid = g.sid, hide = true }, "receiveFrame");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var container = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                Console.WriteLine("Server started!");
               
                Console.ReadLine();
            }
        }
    }
}
