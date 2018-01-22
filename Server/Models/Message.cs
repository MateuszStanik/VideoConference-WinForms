using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Message
    {
        public int sid { get; set; }
        public string nick { get; set; }
        public string roomName { get; set; }
        public string message { get; set; }
    }
}
