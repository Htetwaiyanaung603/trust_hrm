using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    [Table("BonusType")]
    public class BonusType
    {
        [Key]
        public long Id { get; set; }
        public string TypeName { get; set; }
        public long Amount { get; set; }
        public Boolean IsActive { get; set; }
        public string Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<Bonus> Bonus { get; set; }
    }
}
