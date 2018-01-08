﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSockets;
using XSockets.Core.Common.Socket;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace VideoConference
{
    static class Program
    {
        public class Chat : XSocketController
        {


            public void ChatMessage1(string message)
            {
                this.InvokeToAll(message, "ChatMessage");
            }
            public void ChatMessage(string message)
            {
                this.InvokeToAll(new { Text = "dupka" }, "chatmessage");
            }
        }

        [STAThread]
        static void Main()
        {
            //using (var container = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            //{
            //    container.Start();
            //    foreach (var server in container.Servers)
            //    {
            //        Console.WriteLine(server.ConfigurationSetting.Endpoint);
            //    }
            //    try
            //    {
            //        var conn = new XSocketClient("ws://127.0.0.1:4502", "http://localhost", "chat");
            //        conn.Open();

            //        conn.Controller("chat").On<dynamic>("chatmessage", data => Console.WriteLine(data.Text));


            //        //conn.Controller("chat").OnOpen += (sender, connectArgs) => {
            //        //    Console.WriteLine("Open {0}", connectArgs.ClientInfo.Controller);
            //        //};
            //        conn.Controller("chat").On<string>("ChatMessage", data => Console.WriteLine(data));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }

            //    Console.WriteLine("Server started, hit enter to quit");
            //    Console.ReadLine();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
