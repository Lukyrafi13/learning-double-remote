using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfCompanyTypeMap : BaseEntity
    {
        public Guid Id { get; set; }
        public string AnlCode { get; set;}
        public string GroupCode { get; set;}
        public string ProductId { get; set;}
    }
}
