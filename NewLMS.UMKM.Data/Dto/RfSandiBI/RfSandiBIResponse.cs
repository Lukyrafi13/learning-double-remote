using NewLMS.UMKM.Data.Dto;
using NewLMS.UMKM.Data.Dto.RfSandiBIGroup;
using System;

namespace NewLMS.UMKM.Data.Dto.RfSandiBI
{
    public class RfSandiBIResponse : BaseResponse
    {
        public string RfSandiBIId { get; set; }
        public RfSandiBIGroupResponse RfSandiBIGroup { get; set; }
        public string BIType { get; set; }
        public string BICode { get; set; }
        public string BIDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public string CategoryCode { get; set; }
    }

    public class RfSandiBIMinResponse
    {

        public string RfSandiBIId { get; set; }
        public string BIDesc { get; set; }
    }

    public class RfSandiBISimpleResponse
    {
        public string RfSandiBIId { get; set; }
        public RfSandiBIGroupResponse RfSandiBIGroup { get; set; }
        public string BIType { get; set; }
        public string BICode { get; set; }
        public string BIDesc { get; set; }
    }
}
