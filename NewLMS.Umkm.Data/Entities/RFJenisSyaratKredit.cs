using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisSyaratKredit : BaseEntity
    {
        public Guid Id { get; set; }
        public string SyaratCode { get; set; }
        public string SyaratDesc { get; set; }
        public bool? Active { get; set; }
    }
}
