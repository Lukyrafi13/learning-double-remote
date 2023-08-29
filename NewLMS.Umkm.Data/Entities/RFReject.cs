using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFReject : BaseEntity
    {
        public Guid Id { get; set; }
        public string RjCode { get; set; }
        public string RjDesc { get; set; }
        public string CoreCode { get; set; }
        public int? Priority { get; set; }
        public bool Active { get; set; }

    }
}
