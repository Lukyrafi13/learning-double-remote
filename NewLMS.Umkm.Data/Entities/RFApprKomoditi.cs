using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFApprKomoditi : BaseEntity
    {
        public Guid Id { get; set; }
        public string APPR_CODE { get; set; }
        public string APPR_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
