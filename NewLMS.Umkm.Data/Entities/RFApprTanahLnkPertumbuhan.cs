using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFApprTanahLnkPertumbuhan : BaseEntity
    {
        public Guid Id { get; set; }
        public string APPR_CODE { get; set; }
        public string APPR_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
