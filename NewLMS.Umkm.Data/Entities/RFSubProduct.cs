using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFSubProduct : BaseEntity
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set; }
        public string SubProductDesc { get; set; }
        public string ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public RFProduct Product { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public bool? MandNPWP { get; set; }
        public string LPCode { get; set; }
        public string SIKPSkema { get; set; }
        public string SIKPParentSkema { get; set; }
    }
}
