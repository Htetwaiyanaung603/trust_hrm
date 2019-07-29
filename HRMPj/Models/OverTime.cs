using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("OverTime")]
    public class OverTime
    {
        [Key]
        public long Id { get; set; }
        public DateTime OTDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}")]
        public DateTime OTStartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm tt}")]
        public DateTime OTEndTime { get; set; }
        public string Status { get; set; }
        public DateTime ApprovedDate { get; set; }
        public int OTTime { get; set; }  
        public int Year { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long FromEmployeeInfoId { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long ToEmployeeInfoId { get; set; }
        public virtual EmployeeInfo ToEmployeeInfo { get; set; }
        public virtual EmployeeInfo FromEmployeeInfo { get; set; }
    }
}
