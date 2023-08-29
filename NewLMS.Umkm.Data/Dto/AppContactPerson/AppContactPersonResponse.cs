using System;
namespace NewLMS.Umkm.Data.Dto.AppContactPersons
{
    public class AppContactPersonResponseDto
    {
        public Guid Id { get; set; }
        public App App { get; set; }
        public string Nama { get; set; }
        public RFRelationCol Hubungan { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }
        public RFGender JenisKelamin { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RFGenderId { get; set; }
    }
}
