using System;

namespace NewLMS.UMKM.Data
{
    public class RFVEHMAKER : BaseEntity
    {
        public Guid Id { get; set; }
        public string VMKR_CODE { get; set; }
        public string VMKR_DESC { get; set; }
        public string VEH_CODE { get; set;}
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
        public string VCNT_CODE {get; set;}
    }
}