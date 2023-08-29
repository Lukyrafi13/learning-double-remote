using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFTempalateAkadKredit : BaseEntity
    {
        public Guid Id { get; set; }
        public string Urutan { get; set; }
        public string TermDesc { get; set; }

    }
}
