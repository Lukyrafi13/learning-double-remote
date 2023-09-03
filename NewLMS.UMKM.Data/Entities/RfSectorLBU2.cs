using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data
{
    public class RfSectorLBU2 : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        [ForeignKey("Code")]
        public string LBCode1 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        [ForeignKey(nameof(RfSectorLBU1))]
        public string RfSectorLBU1Code { get; set; }
        public bool IsShowing { get; set; }
        public virtual RfSectorLBU1 RfSectorLBU1 { get; set; }
        public virtual ICollection<RfSectorLBU3> RfSectorLBU3s { get; set; }
    }
}
