using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Branch")]
    public class Branch
    {
        [Key]
        public long Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("CompanyId")]
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<Department> Department { get; set; }
        public ICollection<EmployeeInfo> EmployeeInfo { get; set; }
    }
}
