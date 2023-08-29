using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFKepemilikanUsaha : BaseEntity
    {
        public Guid Id { get; set; }
        public string KepemilikanUsahaId { get; set; }
        public string KepemilikanUsahaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }

    }
}
