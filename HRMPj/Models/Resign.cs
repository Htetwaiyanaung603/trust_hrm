using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Resign")]
    public class Resign
    {
        [Key]
        
        public long Id { get; set; }
        public DateTime ResignDate { get; set; }
        public string ResignStatus { get; set; }
        public string Comment { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
