using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFSatuanLuas : BaseEntity
    {
        public Guid Id { get; set; }
        public string SatuanLuas_Id { get; set; }
        public string SatuanLuas_Desc { get; set; }
    }
}
