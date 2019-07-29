using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class LeaveRequestViewModel
    {
        public long Id { get; set; }
        public long CurrentYear { get; set; }
        public DateTime LeaveFromDate { get; set; }
        public DateTime LeaveToDate { get; set; }
      
        public decimal LeaveTotalDay { get; set; }
        public Boolean HalfDay { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Boolean UnPaidLeaveStatus { get; set; }
        public int LeaveRemainDay { get; set; }
        public long? LeaveTypeId { get; set; }
       
      
        public long FromEmployeeInfoId { get; set; }
       
        public long ToEmployeeInfoId { get; set; }
       

    }
}
