using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class DepartmentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]

        public DateTime CreatedDate { get; set; }
        
        public long BranchId { get; set; }
    }
}
