using Bjb.DigitalBisnis.CoreBanking.Models.DealEventEnquiry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.DealEventDepositoEnquiry
{

    public class MPODealEventDepositoEnquiryResponse
    {
        [JsonProperty("0")]
        public MPODealEventDepositoEnquiryDetailResponse mPODealEventEnquiryDepositoResponseDetail { get; set; }
    }

    public class MPODealEventDepositoEnquiryDetailResponse
    {
        [JsonProperty("IBRNM")]
        public string IBRNM { get; set; }

        [JsonProperty("IDLP")]
        public string IDLP { get; set; }

        [JsonProperty("IDLR")]
        public string IDLR { get; set; }

        [JsonProperty("OACCRUE")]
        public string OACCRUE { get; set; }

        [JsonProperty("OBASERT")]
        public string OBASERT { get; set; }

        [JsonProperty("OBUNGA")]
        public string OBUNGA { get; set; }

        [JsonProperty("OENDDT")]
        public string OENDDT { get; set; }

        [JsonProperty("OPOKOK")]
        public string OPOKOK { get; set; }

        [JsonProperty("ORATEDEP")]
        public string ORATEDEP { get; set; }

        [JsonProperty("ORSPCODE")]
        public string ORSPCODE { get; set; }

        [JsonProperty("OSTRDT")]
        public string OSTRDT { get; set; }

        [JsonProperty("OUTSTAND")]
        public string OUTSTAND { get; set; }
    }
}
