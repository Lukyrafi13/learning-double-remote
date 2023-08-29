using System;
namespace NewLMS.UMKM.Data.Dto.RfGenders
{
    public class RfGenderResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string GenderCode { get; set; }
        public string GenderDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public string GenderCodeSIKP { get; set; }
        public string GenderDescSIKP { get; set; }
    }
}
