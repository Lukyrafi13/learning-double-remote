namespace NewLMS.Umkm.Data.Dto.RfInstallmentTypes
{
    public class RfInstallmentTypeResponse : BaseResponse
    {
        public string InstallmentTypeCode { get; set; }
        public string InstallmentTypeDesc { get; set; }
    }

    public class RfInstallmentTypeSimpleResponse
    {
        public string InstallmentTypeCode { get; set; }
        public string InstallmentTypeDesc { get; set; }
    }
}
