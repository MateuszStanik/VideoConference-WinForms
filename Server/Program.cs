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
        public async Task JoinClient(dynamic data)
        {
            nick = data.nick;
            roomName = data.roomName;
            await this.InvokeTo(p => p.roomName == this.roomName, nick, "clientJoined");
        }

        public async Task SendMsg(dynamic data)
        {
            await this.InvokeTo(p => p.roomName == this.roomName, new { content = data.content, author = data.author }, "msgSent");
        }
        public async Task LeaveClient(string clientName)
        {
            await this.InvokeToAll(clientName, "clientLeft");
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
