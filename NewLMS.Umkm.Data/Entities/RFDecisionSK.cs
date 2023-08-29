using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFDecisionSK : BaseEntity
    {
        public Guid Id { get; set; }
        public string DEC_CODE { get; set;}
        public string DEC_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool ACTIVE { get; set;}
    }
}
