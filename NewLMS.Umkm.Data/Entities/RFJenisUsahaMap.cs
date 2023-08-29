using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisUsahaMap : BaseEntity
    {
        public Guid Id { get; set; }
        public string ANL_CODE { get; set;}
        public string KELOMPOK_CODE { get; set;}
        public string PRODUCTID { get; set;}
    }
}
