using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        // [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy HH:mm tt")]
        [Display(Name = "DateTime")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

       
    }
}
