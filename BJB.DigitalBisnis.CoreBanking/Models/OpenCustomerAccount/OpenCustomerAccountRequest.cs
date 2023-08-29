using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.OpenCustomerAccount
{
    public class OpenCustomerAccountRequest
    {
        [JsonProperty("ZLAB")]
        public string ZLAB { get; set; }

        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("ZLAS")]
        public string ZLAS { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLCUS")]
        public string ZLCUS { get; set; }

        [JsonProperty("ZLCLC")]
        public string ZLCLC { get; set; }

        [JsonProperty("ZLACT")]
        public string ZLACT { get; set; }

        [JsonProperty("ZLCTP")]
        public string ZLCTP { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLSHNA")]
        public string ZLSHNA { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLACD")]
        public string ZLACD { get; set; }

        [JsonProperty("ZLOADZ")]
        public string ZLOADZ { get; set; }

        [JsonProperty("ZLJAC")]
        public string ZLJAC { get; set; }

        [JsonProperty("ZLAB2")]
        public string ZLAB2 { get; set; }

        [JsonProperty("ZLAS2")]
        public string ZLAS2 { get; set; }
    }
}
