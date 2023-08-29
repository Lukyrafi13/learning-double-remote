using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFCSBPDetail : BaseEntity
    {
        public Guid Id { get; set; }
        public string CSBPGroupID { get; set; }
        public string CSBPDetailID { get; set; }
        public string CSBPDetailName { get; set; }
        public string CSBPDetailDesc { get; set; }
    }
}
