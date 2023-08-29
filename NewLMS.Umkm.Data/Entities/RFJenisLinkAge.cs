using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFJenisLinkAge : BaseEntity
    {
        public Guid Id { get; set; }
        public string JenisLinkAgeCode { get; set; }
        public string JenisLinkAgeDesc { get; set; }
        public bool? Active { get; set; }
    }
}
