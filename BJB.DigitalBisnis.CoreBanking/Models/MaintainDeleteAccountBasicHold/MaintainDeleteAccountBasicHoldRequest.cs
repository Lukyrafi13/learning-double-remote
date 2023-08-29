using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.MaintainDeleteAccountBasicHold
{
    public class MaintainDeleteAccountBasicHoldRequest
    {
        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLHRN1")]
        public string ZLHRN1 { get; set; }
    }
}
