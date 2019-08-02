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
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime ResignDate { get; set; }
        public string ResignStatus { get; set; }
        public string Comment { get; set; }
        public string Remark { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime ApprovedDate { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long FromEmployeeInfoId { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long ToEmployeeInfoId { get; set; }
        public virtual EmployeeInfo ToEmployeeInfo { get; set; }
        public virtual EmployeeInfo FromEmployeeInfo { get; set; }
    }
}
