using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFTipeDokumen : BaseEntity
    {
        public Guid Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeDesc { get; set; }
        public bool? Active { get; set; }
    }
}
