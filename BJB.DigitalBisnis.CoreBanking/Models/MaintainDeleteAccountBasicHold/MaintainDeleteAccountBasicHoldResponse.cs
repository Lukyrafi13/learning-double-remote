using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.MaintainDeleteAccountBasicHold
{
    public class MPOMaintainDeleteAccountBasicHoldResponse
    {
        [JsonProperty("0")]
        public MPOMaintainDeleteAccountBasicHoldResponseDetail MPOMaintainDeleteAccountBasicHoldResponseDetail { get; set; }
    }

    public class MPOMaintainDeleteAccountBasicHoldResponseDetail
    {
        [JsonProperty("ZLBBN")]
        public string ZLBBN { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLCPNC")]
        public string ZLCPNC { get; set; }

        [JsonProperty("ZLCPNS")]
        public string ZLCPNS { get; set; }

        [JsonProperty("ZLHRN1")]
        public string ZLHRN1 { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLCUS2")]
        public string ZLCUS2 { get; set; }

        [JsonProperty("ZLCUN2")]
        public string ZLCUN2 { get; set; }

        [JsonProperty("ZLBRM2")]
        public string ZLBRM2 { get; set; }

        [JsonProperty("ZLBRN2")]
        public string ZLBRN2 { get; set; }

        [JsonProperty("ZLEANE")]
        public string ZLEANE { get; set; }

        [JsonProperty("ZLSHN2")]
        public string ZLSHN2 { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLCUR")]
        public string ZLCUR { get; set; }

        [JsonProperty("ZLATP")]
        public string ZLATP { get; set; }

        [JsonProperty("ZLEATP")]
        public string ZLEATP { get; set; }

        [JsonProperty("ZLHNO")]
        public string ZLHNO { get; set; }

        [JsonProperty("ZLSDTE")]
        public string ZLSDTE { get; set; }

        [JsonProperty("ZLEDTE")]
        public string ZLEDTE { get; set; }

        [JsonProperty("ZLAMTE")]
        public string ZLAMTE { get; set; }

        [JsonProperty("ZLACOE")]
        public string ZLACOE { get; set; }

        [JsonProperty("ZLHRCE")]
        public string ZLHRCE { get; set; }
    }
}
