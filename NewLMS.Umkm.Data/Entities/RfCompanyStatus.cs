using System;
using System.ComponentModel.DataAnnotations.Schema;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.Data
{
    public class RfCompanyStatus : BaseEntity
    {
        public Guid Id { get; set; }
        public string StatusCode { get; set; }
        public string StatusDesc { get; set; }
        public bool Active { get; set; }
       
    }
}
