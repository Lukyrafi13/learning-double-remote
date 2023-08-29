using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SCJabatan : BaseEntity
    {
        public Guid Id { get; set; }
        public string JAB_CODE { get; set; }
        public string JAB_DESC { get; set; }
        public string SK_CODE { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
        public string SK_LIMIT_CODE { get; set; }
    }
}
