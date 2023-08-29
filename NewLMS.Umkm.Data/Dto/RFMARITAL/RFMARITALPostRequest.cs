namespace NewLMS.Umkm.Data.Dto.RFMARITALs
{
    public class RFMARITALPostRequestDto
    {
        public string MR_CODE { get; set; }        
        public string MR_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool? WITHSPOUSE { get; set; }
        public bool ACTIVE { get; set; }
        public string MR_CODESIKP { get; set; }
        public string MR_DESCSIKP { get; set; }
    }
}
