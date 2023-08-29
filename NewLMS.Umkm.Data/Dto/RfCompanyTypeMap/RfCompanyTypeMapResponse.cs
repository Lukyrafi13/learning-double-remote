using System;
namespace NewLMS.UMKM.Data.Dto.RfCompanyTypeMaps
{
    public class RfCompanyTypeMapResponseDto
    {
        public Guid Id { get; set; }
        public string AnlCode { get; set;}
        public string AnlDesc { get; set;}
        public bool AnlActive { get; set;}
        public string GroupCode { get; set;}
        public string ProductId { get; set;}
    }
}
