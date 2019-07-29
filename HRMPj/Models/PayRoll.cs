using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("PayRoll")]
    public class PayRoll
    {
        [Key]
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasicSalary { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OTFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAllowence { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Bonus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LoanAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LateDebuct { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PenaltyFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TaxFee { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Saving { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NetPay { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public Boolean PrintStatus { get; set; }
        
        [ForeignKey("EmployeeInfoId")]
        public long EmployeeInfoId { get; set; }
        public virtual EmployeeInfo EmployeeInfo { get; set; }
    }
}
