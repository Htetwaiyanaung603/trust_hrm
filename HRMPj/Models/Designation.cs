using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Designation")]
    public class Designation
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("DepartmentId")]
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<EmployeeInfo> EmployeeInfo { get; set; }
    }
}
