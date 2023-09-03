namespace NewLMS.UMKM.Data.Dto.RfInstituteCodes
{
    public class RfInstituteCodeResponse : BaseResponse
    {
        public string ServiceCode { get; set; }
        public string Partner { get; set; }
        public string EconomySector { get; set; }
        public string Cultivation { get; set; }
        public bool Active { get; set; }
    }
}
