using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InterAccountTransfer
{
    public class InterAccountTransferRequest
    {
        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLEAN1")]
        public string ZLEAN1 { get; set; }

        [JsonProperty("ZLREF")]
        public string ZLREF { get; set; }

        [JsonProperty("ZLTCD1")]
        public string ZLTCD1 { get; set; }

        [JsonProperty("ZLDRF1")]
        public string ZLDRF1 { get; set; }

        [JsonProperty("ZLNR1")]
        public string ZLNR1 { get; set; }

        [JsonProperty("ZLNR2")]
        public string ZLNR2 { get; set; }

        [JsonProperty("ZLNR3")]
        public string ZLNR3 { get; set; }

        [JsonProperty("ZLNR4")]
        public string ZLNR4 { get; set; }

        [JsonProperty("ZLTCD2")]
        public string ZLTCD2 { get; set; }

        [JsonProperty("ZLDRF2")]
        public string ZLDRF2 { get; set; }

        [JsonProperty("ZLNR5")]
        public string ZLNR5 { get; set; }

        [JsonProperty("ZLNR6")]
        public string ZLNR6 { get; set; }

        [JsonProperty("ZLNR7")]
        public string ZLNR7 { get; set; }

        [JsonProperty("ZLNR8")]
        public string ZLNR8 { get; set; }

        [JsonProperty("ZLAMZ1")]
        public string ZLAMZ1 { get; set; }

        [JsonProperty("ZLRRT")]
        public string ZLRRT { get; set; }

        [JsonProperty("ZLEXRZ")]
        public string ZLEXRZ { get; set; }
    }
}
