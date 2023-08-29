using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFRelationSurvey : BaseEntity
    {
        public Guid Id { get; set; }
        public string RE_CODE { get; set; }
        public string RE_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
