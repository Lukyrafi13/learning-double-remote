using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfCompanyGroup : BaseEntity
    {
        public Guid Id { get; set; }
        public string AnlCode { get; set; }
        public string AnlDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
