using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFAspekPemasaran : BaseEntity
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set; }
        public string ANL_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool? ACTIVE { get; set; }
    }
}
