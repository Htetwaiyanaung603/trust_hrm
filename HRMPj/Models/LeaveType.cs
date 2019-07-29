using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("LeaveType")]
    public class LeaveType
    {
        [Key]
        public long Id { get; set; }
        public string TypeName { get; set; }
      
       
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public long ServiceDay { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
       
    }
}
