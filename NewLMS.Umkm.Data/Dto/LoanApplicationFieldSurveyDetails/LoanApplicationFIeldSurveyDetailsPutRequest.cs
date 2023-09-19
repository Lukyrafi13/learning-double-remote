using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationFieldSurveyDetails
{
    public class LoanApplicationFIeldSurveyDetailsPutRequest
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
    }
}
