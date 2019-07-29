using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AttendanceViewModel
    {
        public long Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }    
        public long EmployeeInfoId { get; set; }
       
    }
}
