using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int id { get; set; }
        public int sid { get; set; }
        public string nick { get; set; }
        public string roomName { get; set; }
        public string message { get; set; }
    }
}
