using System;

namespace NewLMS.UMKM.Data.Dto.SurveySuppliers
{
    public class SurveySupplierPutRequestDto : SurveySupplierPostRequestDto
    {
        public Guid Id { get; set; }
    }
}
