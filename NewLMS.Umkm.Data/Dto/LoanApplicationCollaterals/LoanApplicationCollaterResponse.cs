using System;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.RfZipCodes;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners
{
    public class LoanApplicationCollateralResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string CollateralBCId { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentReleaseDate { get; set; }
        public DateTime? DocumentExpireDate { get; set; }
        public string DocumentPublisher { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhoods { get; set; }

        public LoanApplicationCollateralOwnerResponse LoanApplicationCollateralOwner { get; set; }
        public RfZipCodeResponse RfZipCode { get; set; }
    }
}

