using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class EmployeeInfoViewModel
    {
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string NRC { get; set; }
        public string Nationality { get; set; }
        public string MartialStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long MobilePhone { get; set; }
        public string CurrentAddress { get; set; }
        public long EmergencyNo { get; set; }
        public long AccountNo { get; set; }
        public long ATMNumber { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UserId { get; set; }
        public long BasicSalary { get; set; }
        public IFormFile EmployeeProfile { get; set; }
        public long BranchId { get; set; }

        public long DepartmentId { get; set; }


        public long DesignationId { get; set; }

        public List<IFormFile> DocumentProfile { get; set; }
    }
}