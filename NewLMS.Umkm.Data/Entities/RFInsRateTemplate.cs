using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFInsRateTemplate : BaseEntity
    {
        public Guid Id {get; set; }
        public string TPLCode { get; set; }
        public string TPLDesc { get; set; }
        public bool? Active { get; set; }
    }
}