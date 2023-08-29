using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AdditionalInformationEnquiry
{
    public class AdditionalInformationEnquiryRequest
    {
        [JsonProperty("BGCUS")]
        public string BGCUS { get; set; }
    }
}
