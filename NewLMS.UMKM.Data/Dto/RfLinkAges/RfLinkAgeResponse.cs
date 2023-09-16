namespace NewLMS.UMKM.Data.Dto.RfLinkAge
{
    public class RfLinkAgeResponse : BaseResponse
    {
        public string LinkAgeCode { get; set; }
        public string LinkAgeDesc { get; set; }
    }

    public class RfLinkAgeSimpleResponse
    {
        public string LinkAgeCode { get; set; }
        public string LinkAgeDesc { get; set; }
    }
}
