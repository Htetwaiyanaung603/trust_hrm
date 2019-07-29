using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class BranchViewModel
    {
        public long Id { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public long CompanyId { get; set; }
        
    }
}
