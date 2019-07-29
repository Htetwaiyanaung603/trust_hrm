using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("AllowanceDetail")]
    public class AllowanceDetail
    {
        [Key]
        public long Id { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        [ForeignKey("AllowanceTypeId")]
        public long AllowanceTypeId { get; set; }
        public virtual AllowanceType AllowanceType { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo Employee { get; set; }
    }
}
