using System;

namespace NewLMS.Umkm.Data.Dto.Surveys
{
    public class SurveyOTSResponse:SurveyOTSPut
    {
        public Guid AppId { get; set; }

        public App App { get; set; }
        public RFRelationSurvey HubunganDebitur { get; set; }
        public RFOwnerCategory BentukBadanUsaha { get; set; }
        public RFOwnerOTS StatusTempatUsaha { get; set; }
        public RFBidangUsahaKUR BidangUsahaKUR { get; set; }
        public RFZipCode KodePos { get; set; }
    }
}
