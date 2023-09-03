using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfSectorLBU1 : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool? IsShowing { get; set; }
        public bool? HideKUR { get; set; }
        public virtual ICollection<RfSectorLBU2> RfSectorLBU2s { get; set; }
    }
}
