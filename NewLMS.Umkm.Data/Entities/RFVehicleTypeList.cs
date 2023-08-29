using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFVehicleTypeList : BaseEntity
    {
        public Guid Id { get; set; }
        public string COL_CODE { get; set;}
        public string VEH_CODE { get; set;}
        
    }
}
