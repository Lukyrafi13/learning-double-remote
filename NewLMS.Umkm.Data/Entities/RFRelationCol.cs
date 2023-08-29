using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFRelationCol : BaseEntity
    {
        public Guid Id { get; set; }
        public string ReCode { get; set; }
        public string ReDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public bool Spouse { get; set; }
       
    }
}
