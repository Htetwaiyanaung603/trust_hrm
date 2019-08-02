using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        [Key]
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string NRC { get; set; }
        public string Nationality { get; set; }
        public string MartialStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public long MobilePhone { get; set; }
        public string CurrentAddress { get; set; }
        public long EmergencyNo { get; set; }
        public long AccountNo { get; set; }
        public long ATMNumber { get; set; }
        public Boolean IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UserId { get; set; }
        public long BasicSalary { get; set; }
        public string EmployeeProfile { get; set; }
        [ForeignKey("BranchId")]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [ForeignKey("DepartmentId")]
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("DesignationId")]
        public long DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public ICollection<Document> Document { get; set; }
        public ICollection<AllowanceDetail> AllowanceDetail { get; set; }
        public ICollection<OverTime> FromOverTimeList { get; set; }
        public ICollection<OverTime> ToOverTimeList { get; set; }
      
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<Bonus> Bonus { get; set; }
        public Resign Resign { get; set; }
        public ICollection<PayRoll> PayRoll { get; set; }
       
        public ICollection<LeaveRequest> FromLeaveRequest { get; set; }
        public ICollection<LeaveRequest> ToLeaveRequest { get; set; }
        public ICollection<Resign> FromResign { get; set; }
        public ICollection<Resign> ToResign { get; set; }
    }
    
}
