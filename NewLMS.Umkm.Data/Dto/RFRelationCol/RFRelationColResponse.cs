using System;
namespace NewLMS.Umkm.Data.Dto.RFRelationCols
{
    public class RFRelationColResponseDto
    {
        public Guid Id { get; set; }
        public string ReCode { get; set; }
        public string ReDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
       public bool Spouse { get; set; }
    }
}
