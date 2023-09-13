using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfCollateralBC : BaseEntity
    {
        [Key]
        [Required]
        public string CollateralCode { get; set; }
        public string CollateralDesc { get; set; }
        public string CollateralType { get; set; }
        public bool Land { get; set; }
        public bool Building { get; set; }
        public string BeaGroup { get; set; }
        public string ColllatealCatCode { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
