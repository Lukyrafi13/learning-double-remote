using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFKategori : BaseEntity
    {
        public Guid Id { get; set; }
        public string KategoriCode { get; set; }
        public string KategoriDesc { get; set; }
        public bool Active { get; set; }

    }
}
