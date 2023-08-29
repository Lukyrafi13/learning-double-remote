using System;

namespace NewLMS.Umkm.Data
{
    public class RFVEHCLASS : BaseEntity
    {
        public Guid Id { get; set; }
        public string VCLS_CODE { get; set; }
        public string VCLS_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
        public string VEH_CODE { get; set;}
        public string VEHMDL_CODE { get; set;}
    }
}