using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public long Id { get; set; }
        public string CompanyName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public ICollection<Branch> Branch { get; set; }

    }
}
