using System;
namespace NewLMS.UMKM.Data.Dto.RFVehModels
{
    public class RFVehModelResponseDto
    {
        public Guid Id { get; set; }
        public string VMDL_CODE { get; set;}
        public string VMDL_DESC { get; set;}
        public string CORE_CODE { get; set;}
        public bool Active { get; set;}
    }
}
