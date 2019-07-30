using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class EmpPayRollViewModel
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public long DepartmentId { get; set; }
        public long DesignationId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
