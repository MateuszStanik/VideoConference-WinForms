using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Common.Socket;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace Server
{
    public class Generic : XSocketController
    {
        protected string nick;
        protected string roomName;
        public async Task JoinRoom(dynamic data)
        {
            nick = data.nick;
            roomName = data.roomName;
            await this.InvokeTo(c => c.roomName == this.roomName, nick, "clientJoined");
        }

        public async Task SendMsg(string content)
        {
            await this.InvokeTo(c => c.roomName == this.roomName, new { content = content, author = nick }, "msgSent");
        }
        public async Task LeaveRoom()
        {
            await this.InvokeTo(c => c.roomName == this.roomName, nick, "clientLeft");
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
