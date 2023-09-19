using System;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class AppraisalPostRequest
    {
        public Guid LoanApplicationCollateralId { get; set; }
        public string PropertyCategory { get; set; }
        public Boolean isInternal { get; set; }
        public Boolean isExternal { get; set; }
        public string Kjpp { get; set; }
        public string Estimator { get; set; }
        public string AppraisalStatus { get; set; }
    }
}
