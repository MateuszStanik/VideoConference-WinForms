using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XSockets;

namespace VideoConference
{
    public partial class Conference : Form
    {

        public Conference()
        {
            InitializeComponent();
        }
        
        private void CreateConnection_Click(object obj, EventArgs e)
        {
            var c = new XSocketClient("ws://127.0.0.1:4502", "http://localhost", "generic");
            c.OnConnected += (sender, eventArgs) => Messages.AppendText("Connected");
            c.Controller("generic").OnOpen += (sender, connectArgs) => { 
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText("Generic Open");
                    }));
                c.Controller("generic").Invoke("CallAllClients");
            };

            c.Open();
            
            c.Controller("generic").On("test", () => {
                this.Invoke(
                    new Action(() =>
                    {
                        Messages.AppendText("Syntaxerror did it!!! ");
                    }));
            });
            
        }

    }
}
