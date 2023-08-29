using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data
{
    public class RFSectorLBU2 : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        [ForeignKey("Code")]
        public string LBCode1 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        [ForeignKey(nameof(RFSectorLBU1))]
        public string RFSectorLBU1Code { get; set; }
        public bool IsShowing { get; set; }
        public virtual RFSectorLBU1 RFSectorLBU1 { get; set; }
        public virtual ICollection<RFSectorLBU3> RFSectorLBU3s { get; set; }
    }
}
