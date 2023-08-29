using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold
{
    public class InputAccountHoldRequest
    {
        /// <summary>
        /// External account debitur
        /// </summary>
        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }
        /// <summary>
        /// start date
        /// </summary>

        [JsonProperty("ZLSDTZ")]
        public string ZLSDTZ { get; set; }
        /// <summary>
        /// expiry date
        /// </summary>

        [JsonProperty("ZLEDTZ")]
        public string ZLEDTZ { get; set; }
        /// <summary>
        /// Amount
        /// </summary>

        [JsonProperty("ZLAMT")]
        public string ZLAMT { get; set; }
        /// <summary>
        /// Department Code
        /// </summary>

        [JsonProperty("ZLACO")]
        public string ZLACO { get; set; } = "ADM";

        [JsonProperty("ZLHRC")]
        public string ZLHRC { get; set; } = "A01";
        /// <summary>
        /// Description 1
        /// </summary>

        [JsonProperty("ZLHDD1")]
        public string ZLHDD1 { get; set; }
        /// <summary>
        /// Description 2
        /// </summary>

        [JsonProperty("ZLHDD2")]
        public string ZLHDD2 { get; set; }
        /// <summary>
        /// Description 3
        /// </summary>

        [JsonProperty("ZLHDD3")]
        public string ZLHDD3 { get; set; }
        /// <summary>
        /// Description 4
        /// </summary>

        [JsonProperty("ZLHDD4")]
        public string ZLHDD4 { get; set; }
    }
}
