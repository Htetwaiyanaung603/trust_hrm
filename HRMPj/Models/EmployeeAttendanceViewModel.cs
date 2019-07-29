using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class EmployeeAttendanceViewModel
    {
        public long EmployeeId { get; set; }
        public string Status { get; set; }
        public DateTime AttendanceDate { get; set; }
        public long BranchId { get; set; }
        public long DepartmentId { get; set; }

    }
}
