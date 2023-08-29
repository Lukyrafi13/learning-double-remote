using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFJenisAkta : BaseEntity
    {
        public Guid Id { get; set; }
        public string AktaCode { get; set; }
        public string AktaDesc { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }
       
    }
}
