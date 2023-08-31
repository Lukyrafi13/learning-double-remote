using System;

namespace NewLMS.UMKM.Data.Dto.Surveys
{
    public class SurveyOTSResponse:SurveyOTSPut
    {
        public Guid AppId { get; set; }

        public LoanApplication LoanApplication { get; set; }
        public RFRelationSurvey HubunganDebitur { get; set; }
        public RfOwnerCategory BentukBadanUsaha { get; set; }
        public RFOwnerOTS StatusTempatUsaha { get; set; }
        public RFBidangUsahaKUR BidangUsahaKUR { get; set; }
        public RfZipCode KodePos { get; set; }
    }
}
