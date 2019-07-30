using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class PayRollViewModel
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OTFee { get; set; }
        public decimal TotalAllowence { get; set; }
        public decimal Bonus { get; set; }
       
 
        public decimal PenaltyFee { get; set; }
      
       
        public decimal NetPay { get; set; }
      
        public string Year { get; set; }
        public string Month { get; set; }
    
        public long EmployeeInfoId { get; set; }
        
    }
}
