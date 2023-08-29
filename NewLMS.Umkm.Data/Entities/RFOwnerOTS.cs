using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFOwnerOTS : BaseEntity
    {
        public Guid Id { get; set; }
        public string OWN_CODE { get; set; }
        public string OWN_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool Active { get; set; }
    }
}
