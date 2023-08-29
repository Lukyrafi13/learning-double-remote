using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFLoanPurpose : BaseEntity
    {
        public Guid Id { get; set; }
        public string LP_CODE { get; set;}
        public string LP_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool Active { get; set;}
        public int? MAXPROD { get; set;}

    }
}
