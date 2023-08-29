using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFOwnerCategory : BaseEntity
    {
        public Guid Id { get; set; }
        public string OwnCode { get; set; }
        public string OwnDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
       
    }
}
