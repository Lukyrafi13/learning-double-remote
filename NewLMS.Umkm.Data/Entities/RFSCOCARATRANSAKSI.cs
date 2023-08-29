using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFSCOCARATRANSAKSI : BaseEntity
    {
        public Guid Id { get; set; }
        public string SCO_CODE { get; set; }
        public string SCO_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}