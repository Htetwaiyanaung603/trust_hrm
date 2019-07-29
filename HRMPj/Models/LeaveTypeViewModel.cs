using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class LeaveTypeViewModel
    {
        public long Id { get; set; }
        public string TypeName { get; set; }
      
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public long ServiceDay { get; set; }
    }
}
