

using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplications
{
    public class LoanApplicationAppInfoApprResponse
    {
        public string LoanApplicationId { get; set; }
        public string SubProduct { get; set; }
        public string Name { get; set; } 
        public string Branch { get; set; }
        public string SIUPNumber { get; set; }
        public string CompanyOld { get; set; }
        public string Address { get; set; } 
        public string PhoneNumber { get; set; }

    }

    public class LoanApplicationAppInfoApprSurveyorResponse
    {
        public string Regency { get; set; }
        public string Branch { get; set; }
        public string AccountOfficer { get; set; }
        public string LoanApplicationId { get; set; }
        public string Product { get; set; }
        public string Name { get; set; }
        public string NPWP { get; set; }
        public string NoIdentity { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BookingOffice { get; set; }
        public bool IsBusinessCycle { get; set; }

    }
}
