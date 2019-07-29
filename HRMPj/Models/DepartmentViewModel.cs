using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class DepartmentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public long BranchId { get; set; }
    }
}
