using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFBank : BaseEntity
    {
        public Guid Id { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
        public string CoreCode { get; set; }
        public bool? Active { get; set; }

    }
}
