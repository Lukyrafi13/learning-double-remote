using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFNegaraPenempatan : BaseEntity
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
