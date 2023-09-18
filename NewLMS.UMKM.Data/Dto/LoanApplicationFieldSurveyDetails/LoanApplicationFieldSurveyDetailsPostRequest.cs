using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails
{
    public class LoanApplicationFieldSurveyDetailsPostRequest
    {
        public string FieldSurveyDetail { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProductType { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public int PaymentMethodId { get; set; }
        public int StandingBusiness { get; set; }
    }
}
