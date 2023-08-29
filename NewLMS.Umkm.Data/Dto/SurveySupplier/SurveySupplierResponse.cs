using System;
namespace NewLMS.Umkm.Data.Dto.SurveySuppliers
{
    public class SurveySupplierResponseDto : SurveySupplierPostRequestDto
    {
        public Guid Id { get; set; }
        public Survey Survey { get; set; }
        public RFPaymentMethod MetodePembayaran { get; set; }
    }
}
