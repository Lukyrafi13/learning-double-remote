using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFTenorMapping : BaseEntity
    {
        public Guid Id { get; set; }
        public string TNCode { get; set; }
        public string SiklusCode { get; set; }
        public string ProductId { get; set; }
       
    }
}
