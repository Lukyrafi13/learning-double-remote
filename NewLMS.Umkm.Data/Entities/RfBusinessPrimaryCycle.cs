using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RfBusinessPrimaryCycle : BaseEntity
    {
        public Guid Id { get; set; }
        public string CycleCode { get; set; }
        public string CycleDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
