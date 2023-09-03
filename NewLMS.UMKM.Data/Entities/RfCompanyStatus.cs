using System;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.UMKM.Data;

namespace NewLMS.UMKM.Data
{
    public class RfCompanyStatus : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
       
    }
}
