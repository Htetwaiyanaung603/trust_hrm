using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("AllowancdType")]
    public class AllowanceType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long AmmountPerDay { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<AllowanceDetail> AllowanceDetails { get; set; }

    }
}
