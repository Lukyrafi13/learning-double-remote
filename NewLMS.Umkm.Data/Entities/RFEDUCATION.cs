using System;

namespace NewLMS.Umkm.Data
{
    public class RFEDUCATION : BaseEntity
    {
        public Guid Id { get; set; }
        public string ED_CODE { get; set; }
        public string ED_DESC { get; set; }
        public string ED_CODESIKP { get; set; }
        public string ED_DESCSIKP { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}