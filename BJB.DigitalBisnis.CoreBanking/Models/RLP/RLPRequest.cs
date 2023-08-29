using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.RLP
{
    public class RLPRequest
    {
        [JsonProperty("ZLLNP")]
        public string ZLLNP { get; set; }

        [JsonProperty("ZLLNR")]
        public string ZLLNR { get; set; }

        [JsonProperty("ZLBRNM")]
        public string ZLBRNM { get; set; }

        [JsonProperty("ZLCUS")]
        public string ZLCUS { get; set; }

        [JsonProperty("ZLCPNC")]
        public string ZLCPNC { get; set; }

        [JsonProperty("ZLCLC")]
        public string ZLCLC { get; set; }

        [JsonProperty("ZLSCCY")]
        public string ZLSCCY { get; set; }

        [JsonProperty("ZLABZ")]
        public string ZLABZ { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLANZ")]
        public string ZLANZ { get; set; }

        [JsonProperty("ZLASZ")]
        public string ZLASZ { get; set; }

        [JsonProperty("ZLPOAZ")]
        public string ZLPOAZ { get; set; }

        [JsonProperty("ZLRUIZ")]
        public string ZLRUIZ { get; set; }

        [JsonProperty("ZLRC1Z")]
        public string ZLRC1Z { get; set; }

        [JsonProperty("ZLRC2Z")]
        public string ZLRC2Z { get; set; }

        [JsonProperty("ZLRC3Z")]
        public string ZLRC3Z { get; set; }

        [JsonProperty("ZLRCOZ")]
        public string ZLRCOZ { get; set; }

        [JsonProperty("ZLDET1")]
        public string ZLDET1 { get; set; }

        [JsonProperty("ZLDET2")]
        public string ZLDET2 { get; set; }

        [JsonProperty("ZLDET3")]
        public string ZLDET3 { get; set; }

        [JsonProperty("ZLDET4")]
        public string ZLDET4 { get; set; }

        [JsonProperty("ZLSRC")]
        public string ZLSRC { get; set; }

        [JsonProperty("ZLUC1")]
        public string ZLUC1 { get; set; }

        [JsonProperty("ZLUC2")]
        public string ZLUC2 { get; set; }

        [JsonProperty("ZLNDA")]
        public string ZLNDA { get; set; }
    }
}
