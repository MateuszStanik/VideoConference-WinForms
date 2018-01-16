using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    [Table("Conference")]
    public class Conference
    {
        [Key]
        public int id { get; set; }
        public string Messages { get; set; }
        DateTime ConferenceDate { get; set; }
    }
}
