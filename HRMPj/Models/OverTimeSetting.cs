using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("OverTimeSetting")]
    public class OverTimeSetting
    {
        [Key]
        public long Id { get; set; }
        public float Amount { get; set; }
        public int Hour { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
