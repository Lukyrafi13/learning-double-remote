using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFBidangUsahaKUR : BaseEntity
    {
        public Guid Id { get; set; }
        public string BTCode { get; set; }
        public string BTDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
