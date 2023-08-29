using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFStatusTarget : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
       
    }
}
