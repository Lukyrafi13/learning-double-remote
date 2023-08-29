using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class AppContactPerson : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("AppId")]
        public App App { get; set; }
        public string Nama { get; set; }
        [ForeignKey("RFRelationColId")]
        public RFRelationCol Hubungan { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }
        [ForeignKey("RFGenderId")]
        public RFGender JenisKelamin { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RFGenderId { get; set; }
    }
}