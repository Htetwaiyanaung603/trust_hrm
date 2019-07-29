using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Bonus")]
    public class Bonus
    {
        [Key]
        public long Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
        [ForeignKey("BonusTypeId")]
        public long BonusTypeId { get; set; }
        public virtual BonusType BonusType { get; set; }
    }
}
