using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFLamaUsahaLain : BaseEntity
    {
        public Guid Id { get; set; }
        public string ANLCode { get; set; }
        public string ANLDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }

    }
}
