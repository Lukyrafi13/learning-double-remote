using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFDocumentAgunan : BaseEntity
    {
        public Guid Id { get; set; }
        public string DocCode { get; set; }
        public string ColCode { get; set; }
        public bool Active { get; set; }
       
    }
}
