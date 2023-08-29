using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFCSBPHeader : BaseEntity
    {
        public Guid Id { get; set; }
        public string CSBPGroupID { get; set; }
        public string CSBPGroupName { get; set; }
        public string CSBPGroupDesc { get; set; }
    }
}
