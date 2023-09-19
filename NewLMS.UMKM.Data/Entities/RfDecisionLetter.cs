using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfDecisionLetter : BaseEntity
    {
        [Key]
        [Required]
        public string DecisionLeterCode { get; set; }
        public string DecisionLeterDesc { get; set; }

        [ForeignKey(nameof(RfDecisionLeterType))]
        public string DecisionLeterTypeCode { get; set; }

        public string DecisionLeterNumber { get; set; }
        public string DecisionLeterBy { get; set; }
        public string DecisionLeterMatter { get; set; }
        public DateTime? DecisionLeterDate { get; set; }
        public string DecisionLeterClausal { get; set; }
        public DateTime? DecisionLeterExpDate { get; set; }
        public double? Limit { get; set; }

        public virtual RfDecisionLeterType RfDecisionLeterType { get; set; }
    }
}
