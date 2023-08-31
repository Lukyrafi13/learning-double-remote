using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFPlacementCountry : BaseEntity
    {
        public Guid Id { get; set; }
        public string NegaraCode { get; set; }
        public string NegaraDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? ShowKUR { get; set; }
        public double? Kurs { get; set; }
        public bool? Active { get; set; }
       
    }
}
