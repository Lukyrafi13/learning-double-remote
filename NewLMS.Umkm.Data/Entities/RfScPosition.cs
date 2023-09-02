using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfScPosition : BaseEntity
    {
        public string ScPositionCode { get; set; }
        public string ScPositionDesc { get; set; }
        public string SKCode { get; set; }
        
        [ForeignKey(nameof(RfDecisionLetter))]
        public string DecisionLeterCode { get; set; }
        
        public string CoreCode { get; set; }
        public bool Active { get; set; }

        public virtual RfDecisionLetter RfDecisionLetter { get; set; }
    }
}
