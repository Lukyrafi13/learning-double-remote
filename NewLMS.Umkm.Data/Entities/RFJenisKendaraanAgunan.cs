using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisKendaraanAgunan : BaseEntity
    {
        public Guid Id { get; set; }
        public string VEH_CODE { get; set;}
        public string VEH_DESC { get; set;}
    }
}
