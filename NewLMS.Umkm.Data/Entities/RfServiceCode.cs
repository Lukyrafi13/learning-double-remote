using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfServiceCode : BaseEntity
    {
        public Guid Id { get; set; }
        public string ServiceCode { get; set; }
        public string Partner { get; set; }
        public string EconomySector { get; set; }
        public string Cultivation { get; set; }
        public bool Active { get; set; }

    }
}
