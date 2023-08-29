using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFSifatKredit : BaseEntity
    {
        public Guid Id { get; set; }
        public string SKCode { get; set; }
        public string SKDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
       
    }
}
