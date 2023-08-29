using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFPilihanPemutus : BaseEntity
    {
        public Guid Id { get; set; }
        public string PemCode { get; set; }
        public string PemDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
