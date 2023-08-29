using System;

namespace NewLMS.Umkm.Data.Dto.SurveySuppliers
{
    public class SurveySupplierPutRequestDto : SurveySupplierPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
