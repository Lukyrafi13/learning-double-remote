using System;

namespace NewLMS.UMKM.Data.Dto.RFRelationCols
{
    public class RFRelationColPutRequestDto
    {
        public string ReCode { get; set; }
        public string ReDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
       public bool Spouse { get; set; }
    }
}
