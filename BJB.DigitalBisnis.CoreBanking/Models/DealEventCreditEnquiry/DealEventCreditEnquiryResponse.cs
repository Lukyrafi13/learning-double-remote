using Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.DealEventEnquiry
{
    public class MPODealEventCreditEnquiryResponse
    {
        [JsonProperty("0")]
        public MPODealEventCreditEnquiryResponseDetail mPODealEventCreditEnquiryResponseDetail { get; set; }
    }

    public class MPODealEventCreditEnquiryResponseDetail
    {
        [JsonProperty("#CIF")]
        public string CIF { get; set; }

        [JsonProperty("#ENDDATE")]
        public string ENDDATE { get; set; }

        [JsonProperty("#INTFREQ")]
        public string INTFREQ { get; set; }

        [JsonProperty("#LASTOUTS")]
        public string LASTOUTS { get; set; }

        [JsonProperty("#NAMA")]
        public string NAMA { get; set; }

        [JsonProperty("#NOMANGS")]
        public string NOMANGS { get; set; }

        [JsonProperty("#PLAFAWAL")]
        public string PLAFAWAL { get; set; }

        [JsonProperty("#RECACC")]
        public string RECACC { get; set; }

        [JsonProperty("#REPAYINT")]
        public string REPAYINT { get; set; }

        [JsonProperty("#STARTDATE")]
        public string STARTDATE { get; set; }

        [JsonProperty("@OSBRNM")]
        public string OSBRNM { get; set; }

        [JsonProperty("@OSDLP")]
        public string OSDLP { get; set; }

        [JsonProperty("@OSDLR")]
        public string OSDLR { get; set; }
    }
}
