using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFMappingAgunan2 : BaseEntity
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ColCode { get; set; }
        public string ColDesc { get; set; }
        public bool Active { get; set; }
       
    }
}
