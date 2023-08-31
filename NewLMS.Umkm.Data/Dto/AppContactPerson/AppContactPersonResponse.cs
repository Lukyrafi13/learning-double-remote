using System;
namespace NewLMS.UMKM.Data.Dto.AppContactPersons
{
    public class AppContactPersonResponseDto
    {
        public Guid Id { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public string Nama { get; set; }
        public RFRelationCol Hubungan { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }
        public RfGender JenisKelamin { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RfGenderId { get; set; }
    }
}
