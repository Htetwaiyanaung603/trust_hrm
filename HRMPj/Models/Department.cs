using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("BranchId")]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public ICollection<Designation> Designation { get; set; }
        public ICollection<EmployeeInfo> EmployeeInfo { get; set; }
    }
}
