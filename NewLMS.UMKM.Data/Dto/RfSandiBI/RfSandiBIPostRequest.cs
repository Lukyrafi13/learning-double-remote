using System;

namespace NewLMS.UMKM.Data.Dto.RfSandiBI
{
    public class RfSandiBIPostRequest
    {
        public string BIGroup { get; set; }
        public string BIType { get; set; }
        public string BICode { get; set; }
        public string BIDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public string CategoryCode { get; set; }
    }

}
