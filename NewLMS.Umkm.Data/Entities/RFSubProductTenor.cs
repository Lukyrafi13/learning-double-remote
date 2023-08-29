using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFSubProductTenor : BaseEntity
    {
        public Guid Id { get; set; }
        public string SubProductId { get; set;}
        public string TNCode { get; set;}
        public bool Active { get; set;}
    }
}
