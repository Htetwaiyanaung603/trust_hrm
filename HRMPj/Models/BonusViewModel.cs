using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class BonusViewModel
    {
        public long Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        
        public long EmployeeInfoId { get; set; }
      
      
        public long BonusTypeId { get; set; }
     
    }
}
