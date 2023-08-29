using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFPaymentMethod : BaseEntity
    {
        public Guid Id { get; set; }
        public string PAY_CODE { get; set; }
        public string PAY_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
