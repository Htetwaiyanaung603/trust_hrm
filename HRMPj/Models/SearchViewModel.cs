using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class SearchViewModel
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long DepartmentId { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
