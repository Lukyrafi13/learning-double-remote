using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class AppContactPerson : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("AppId")]
        public LoanApplication LoanApplication { get; set; }
        public string Nama { get; set; }
        [ForeignKey("RFRelationColId")]
        public RFRelationCol Hubungan { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }
        [ForeignKey("RfGenderId")]
        public RfGender JenisKelamin { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RfGenderId { get; set; }
    }
}