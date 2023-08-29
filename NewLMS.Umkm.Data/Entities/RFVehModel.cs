using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFVehModel : BaseEntity
    {
        public Guid Id { get; set; }
        public string VMDL_CODE { get; set;}
        public string VMDL_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool Active { get; set;}
    }
}
