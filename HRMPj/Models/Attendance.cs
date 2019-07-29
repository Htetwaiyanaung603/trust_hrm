using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        public long Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public long BranchId { get; set; }
        public long DepartmentId { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
