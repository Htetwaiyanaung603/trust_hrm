using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AttendanceSearchViewModel
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long DepartmentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
