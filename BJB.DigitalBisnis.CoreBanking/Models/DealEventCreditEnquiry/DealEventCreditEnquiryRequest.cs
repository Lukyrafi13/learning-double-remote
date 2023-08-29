using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.DealEventEnquiry
{
    public class DealEventCreditEnquiryRequest
    {
        [JsonProperty("@OSDLR")]
        public string OSDLR { get; set; }

        [JsonProperty("@OSDLP")]
        public string OSDLP { get; set; }

        [JsonProperty("@OSBRNM")]
        public string OSBRNM { get; set; }
    }
}
