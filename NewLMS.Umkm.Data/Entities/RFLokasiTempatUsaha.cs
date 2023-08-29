using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFLokasiTempatUsaha : BaseEntity
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set;}
        public string ANL_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool ACTIVE { get; set;}
    }
}
