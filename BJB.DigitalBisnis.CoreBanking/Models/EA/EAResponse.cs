using Bjb.DigitalBisnis.CoreBanking.Models.RLP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.EA
{
    public class EAResponse
    {
        [JsonProperty("0")]
        public EAResponseDetail eAResponseDetail { get; set; }
    }

    public class EAResponseDetail
    {
        [JsonProperty("ZLEANS")]
        public string ZLEANS { get; set; }

        [JsonProperty("ZLACCZ")]
        public string ZLACCZ { get; set; }

        [JsonProperty("ZLSHNS")]
        public string ZLSHNS { get; set; }

        [JsonProperty("ZLATPS")]
        public string ZLATPS { get; set; }

        [JsonProperty("ZLCCYS")]
        public string ZLCCYS { get; set; }

        [JsonProperty("ZLABS")]
        public string ZLABS { get; set; }

        [JsonProperty("ZLANS")]
        public string ZLANS { get; set; }

        [JsonProperty("ZLASS")]
        public string ZLASS { get; set; }

        [JsonProperty("ZLACSS")]
        public string ZLACSS { get; set; }

        [JsonProperty("ZLEANZ")]
        public string ZLEANZ { get; set; }

        [JsonProperty("ZLS105")]
        public string ZLS105 { get; set; }
    }
}