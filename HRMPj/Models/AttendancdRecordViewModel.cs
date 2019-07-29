using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AttendancdRecordViewModel
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<string> AttDateList { get; set; }

    }
}
