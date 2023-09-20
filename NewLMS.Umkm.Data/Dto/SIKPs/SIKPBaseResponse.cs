using System;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;

namespace NewLMS.Umkm.Data.Dto.SIKPs
{
    public class SIKPBaseResponse
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public SIKPRequestResponse SIKPRequest { get; set; }
        public SIKPResponseResponse SIKPResponse { get; set; }
        public string CIF { get; set; }
        
        public RfParameterDetailResponse RfOwnerCategory { get; set; }
        public LoanApplicationInfoResponse Info { get; set; }
    }

    public class SIKPTableResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string DataSource { get; set; }
        public string LoanApplicationId { get; set; }
    }
}

