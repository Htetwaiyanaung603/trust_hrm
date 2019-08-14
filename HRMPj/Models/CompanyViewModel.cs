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

        //[Display(Name = "DateTime")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMMM/yyyy}")]
        public DateTime CreatedDate { get; set; }

       
    }
}
