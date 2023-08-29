using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisAsuransi : BaseEntity
    {
        public Guid Id { get; set; }
        public string JenisCode { get; set; }
        public string JenisDesc { get; set; }
        public bool? Active { get; set; }
    }
}
