using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfCategory : BaseEntity
    {
        public Guid Id { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryDesc { get; set; }
        public bool Active { get; set; }

    }
}
