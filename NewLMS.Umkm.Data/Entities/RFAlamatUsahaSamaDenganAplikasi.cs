using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AlamatUsahaSamaDenganAplikasi
 : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusAlamat_Code { get; set; }
        public string StatusAlamat_Desc { get; set; }

    }
}
