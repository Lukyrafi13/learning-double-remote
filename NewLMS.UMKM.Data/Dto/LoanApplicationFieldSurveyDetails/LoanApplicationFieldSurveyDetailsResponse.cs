using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails
{
    public class LoanApplicationFieldSurveyDetailsResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string FieldSurveyDetail { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProductType { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public int PamentMethodId { get; set; }
        public int StandingBusiness { get; set; }

        public virtual RfParameterDetailSimpleResponse PaymentMethod { get; set; }
    }
}
