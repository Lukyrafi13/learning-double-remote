using System;

namespace NewLMS.Umkm.Data.Dto.AppContactPersons
{
    public class AppContactPersonPostRequestDto
    {
        public string Nama { get; set; }
        public string NomorHandphone { get; set; }
        public string AlamatEmail { get; set; }

        public Guid AppId { get; set; }
        public Guid? RFRelationColId { get; set; }
        public Guid? RFGenderId { get; set; }
    }
}
