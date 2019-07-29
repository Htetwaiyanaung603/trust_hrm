using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class OverTimeSettingViewModel
    {
        public long Id { get; set; }
        public float Amount { get; set; }
        public int Hour { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
