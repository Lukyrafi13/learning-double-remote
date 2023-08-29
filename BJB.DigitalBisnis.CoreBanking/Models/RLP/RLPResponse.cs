using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.RLP
{
    public class RLPResponse
    {
        [JsonProperty("0")]
        public RLPResponseDetail RlpResponseDetail { get; set; }
    }

    public class RLPResponseDetail
    {
        [JsonProperty("ZLLNP")]
        public string ZLLNP { get; set; }

        [JsonProperty("ZLLNR")]
        public string ZLLNR { get; set; }

        [JsonProperty("ZLBRNM")]
        public string ZLBRNM { get; set; }

        [JsonProperty("ZLCPNC")]
        public string ZLCPNC { get; set; }

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

        [JsonProperty("ZLRC1Z")]
        public string ZLRC1Z { get; set; }

        [JsonProperty("ZLNDA")]
        public string ZLNDA { get; set; }

        [JsonProperty("ZLLNRE")]
        public string ZLLNRE { get; set; }

        [JsonProperty("ZLLNRD")]
        public string ZLLNRD { get; set; }

        [JsonProperty("ZLCUN")]
        public string ZLCUN { get; set; }

        [JsonProperty("ZLSDTZ")]
        public string ZLSDTZ { get; set; }

        [JsonProperty("ZLMDTZ")]
        public string ZLMDTZ { get; set; }

        [JsonProperty("ZLPDTZ")]
        public string ZLPDTZ { get; set; }

        [JsonProperty("ZLCUR")]
        public string ZLCUR { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLUIZ")]
        public string ZLUIZ { get; set; }

        [JsonProperty("ZLUPZ")]
        public string ZLUPZ { get; set; }

        [JsonProperty("ZLRUFZ")]
        public string ZLRUFZ { get; set; }

        [JsonProperty("ZLTRZ")]
        public string ZLTRZ { get; set; }

        [JsonProperty("ZLTRD")]
        public string ZLTRD { get; set; }

        [JsonProperty("ZLPROZ")]
        public string ZLPROZ { get; set; }

        [JsonProperty("ZLABT")]
        public string ZLABT { get; set; }

        [JsonProperty("ZLANT")]
        public string ZLANT { get; set; }

        [JsonProperty("ZLAST")]
        public string ZLAST { get; set; }

        [JsonProperty("ZLCC1Z")]
        public string ZLCC1Z { get; set; }

        [JsonProperty("CHS12")]
        public string CHS12 { get; set; }
    }
}
