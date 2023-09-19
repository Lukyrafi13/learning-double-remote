using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.LoanApplicationFacilities
{
    public class LoanApplicationFacilityPostRequest
    {
        public Guid LoanApplicationId { get; set; }
        public int ApplicationTypeId { get; set; }
        public string PlacementCountryCode { get; set; }
        public string LoanPurposeId { get; set; }
        public long SubmittedPlafond { get; set; }
        public string SubProductId { get; set; }
        public string TenorCode { get; set; }
        public string FacilityPurpose { get; set; }
        public string InstallmentType { get; set; }
        public double Interest { get; set; }
        public int NatureOfCreditId { get; set; }
        public long PrincipalInstallment { get; set; }
        public long InterestInstallment { get; set; }
        public string? SectorLBU3Code { get; set; }
    }
}
