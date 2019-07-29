using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class OverTimeViewModel
    {
        public long Id { get; set; }
        public DateTime OTDate { get; set; }
        public DateTime OTStartTime { get; set; }
        public DateTime OTEndTime { get; set; }
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int OTTime { get; set; }
        public int Year { get; set; }

        public long FromEmployeeInfoId { get; set; }
        
        public long ToEmployeeInfoId { get; set; }
        
    }
}
