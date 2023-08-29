using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfSectorLBU3 : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Type { get; set; }
        public int Group { get; set; }
        [ForeignKey("Code")]
        public string LBCode2 { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public string CategoryCode { get; set; }
        [ForeignKey(nameof(RfSectorLBU2))]
        public string RfSectorLBU2Code { get; set; }
        public bool IsShowing { get; set; }
        public virtual RfSectorLBU2 RfSectorLBU2 { get; set; }
        public virtual ICollection<Prospect> Prospects { get; set; }
    }
}
