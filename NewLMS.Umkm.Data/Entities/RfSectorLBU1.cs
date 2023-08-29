using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data
{
    public class RFSectorLBU1 : BaseEntity
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string CoreCode { get; set; }
        public bool? IsShowing { get; set; }
        public bool? HideKUR { get; set; }
        public virtual ICollection<RFSectorLBU2> RFSectorLBU2s { get; set; }
    }
}
