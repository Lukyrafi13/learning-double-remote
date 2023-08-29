using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFKodeDinas : BaseEntity
    {
        public Guid Id { get; set; }
        public string KodeDinas { get; set; }
        public string Mitra { get; set; }
        public string SektorEkonomi { get; set; }
        public string Budidaya { get; set; }
        public bool Active { get; set; }

    }
}
