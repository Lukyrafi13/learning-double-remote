using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.DealEventDepositoEnquiry
{
    public class DealEventDepositoEnquiryRequest
    {
        [JsonProperty("IDLR")]
        public string IDLR { get; set; }

        [JsonProperty("IDLP")]
        public string IDLP { get; set; }

        [JsonProperty("IBRNM")]
        public string IBRNM { get; set; }
    }
}
