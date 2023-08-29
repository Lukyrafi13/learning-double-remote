using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFSatuanKapasitas : BaseEntity
    {
        public Guid Id { get; set; }
        public string SatuanKapasitas_Id { get; set; }
        public string SatuanKapasitas_Desc { get; set; }
    }
}
