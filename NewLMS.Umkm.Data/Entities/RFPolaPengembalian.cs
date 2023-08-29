using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFPolaPengembalian : BaseEntity
    {
        public Guid Id { get; set; }
        public string PolaCode { get; set; }
        public string PolaDesc { get; set; }
        public bool? Active { get; set; }
    }
}
