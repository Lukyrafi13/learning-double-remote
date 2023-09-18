using NewLMS.UMKM.Data.Entities;
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
        public int PhoneNumber { get; set; }
        public int PamentMethodId { get; set; }
        public int StandingBusiness { get; set; }

        public virtual RfParameterDetail PaymentMethod { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}
