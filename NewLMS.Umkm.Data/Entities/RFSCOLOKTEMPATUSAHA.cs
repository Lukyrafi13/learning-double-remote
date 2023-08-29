using System;

namespace NewLMS.Umkm.Data
{
    public class RFSCOLOKTEMPATUSAHA : BaseEntity
    {
        public Guid Id { get; set; }
        public string SCO_CODE { get; set; }
        public string SCO_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}