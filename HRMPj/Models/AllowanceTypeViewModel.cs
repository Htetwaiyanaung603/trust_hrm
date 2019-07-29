using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class AllowanceTypeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long AmmountPerDay { get; set; }
        public string Status { get; set; }
     
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
