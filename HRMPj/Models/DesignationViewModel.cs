using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class DesignationViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public long DepartmentId { get; set; }
        
    }
}
