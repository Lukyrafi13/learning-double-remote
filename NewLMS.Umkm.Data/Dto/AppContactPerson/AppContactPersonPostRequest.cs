using System;

namespace NewLMS.UMKM.Data.Dto.AppContactPersons
{
    public class AppContactPersonPostRequestDto
    {
        public string Nama { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RfGenderId { get; set; }
    }
}
