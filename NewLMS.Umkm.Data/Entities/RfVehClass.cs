using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfVehClass : BaseEntity
    {
        [Key]
        [Required]
        public string VehClassCode { get; set; }
        public string VehClassDesc { get; set; }

        [ForeignKey(nameof(RfVehType))]
        public string VehCode { get; set; }
        
        [ForeignKey(nameof(RfVehModel))]
        public string VehModelCode { get; set; }

        [ForeignKey(nameof(RfVehMaker))]
        public string VehMakerCode { get; set; }

        public string CoreCode { get; set; }
        public bool Active { get; set; }

        public virtual RfVehType RfVehType { get; set; }
        public virtual RfVehModel RfVehModel { get; set; }
        public virtual RfVehMaker RfVehMaker { get; set; }
    }
}
