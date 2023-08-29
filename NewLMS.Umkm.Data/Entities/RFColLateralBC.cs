using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFColLateralBC : BaseEntity
    {
        public Guid Id { get; set; }
        public string ColCode { get; set; }
        public string ColDesc { get; set; }
        public string ColType { get; set; }
        public string ColcatCode { get; set; }
        public string CoreCode { get; set; }
        public bool Land { get; set; }
        public bool Building { get; set; }
        public string BeaGroup { get; set; }
        public bool Active { get; set; }
       
    }
}
