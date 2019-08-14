using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("LeaveRequest")]
    public class LeaveRequest
    {
        [Key]
        public long Id { get; set; }
        public long CurrentYear { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime LeaveFromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime LeaveToDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LeaveTotalDay { get; set; }
        public string HalfDay { get; set; }       
        public string Status { get; set; }
        public string Description { get; set; }
        public string UnPaidLeaveStatus { get; set; }
        public int LeaveRemainDay { get; set; }
        [ForeignKey("LeaveTypeId")]
        public long? LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long FromEmployeeInfoId { get; set; }
        [ForeignKey("EmployeeInfoId")]
        public long ToEmployeeInfoId { get; set; }
        public virtual EmployeeInfo ToEmployeeInfo { get; set; }
        public virtual EmployeeInfo FromEmployeeInfo { get; set; }
    }
}
