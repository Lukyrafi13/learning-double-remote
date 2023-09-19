using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfDecisionLeterType : BaseEntity
    {
        [Key]
        [Required]
        public string DecisionLeterTypeCode { get; set; }
        public string DecisionLeterTypeDesc { get; set; }
    }
}
