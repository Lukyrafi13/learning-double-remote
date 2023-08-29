using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFCaraPengikatan : BaseEntity
    {
        public Guid Id { get; set; }
        public string PK_CODE { get; set; }
        public string PK_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
