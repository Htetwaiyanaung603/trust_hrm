using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AllowanceDetailViewModel
    {
        public long Id { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
       
        public long AllowanceTypeId { get; set; }
        
      
        public long EmployeeInfoId { get; set; }
  
    }
}
