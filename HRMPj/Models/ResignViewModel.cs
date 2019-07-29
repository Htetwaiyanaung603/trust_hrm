using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class ResignViewModel
    {
        public long Id { get; set; }
        public DateTime ResignDate { get; set; }
        public string ResignStatus { get; set; }
        public string Comment { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string Status { get; set; }
        public string Year { get; set; }
    
        public long EmployeeInfoId { get; set; }
       
    }
}
