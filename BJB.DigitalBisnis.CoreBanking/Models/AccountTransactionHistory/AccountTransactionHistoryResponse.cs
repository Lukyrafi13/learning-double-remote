using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountTransactionHistory
{
    public class MPOAccountTransactionHistoryResponse
    {
        [JsonProperty("0")]
        public MPOAccountTransactionHistoryResponseDetail MPOAccountTransactionHistoryResponseDetail { get; set; }
    }
    public class MPOAccountTransactionHistoryResponseDetail
    {
        [JsonProperty("ZHTIT2")]
        public string ZHTIT2 { get; set; }

        [JsonProperty("ZHNR")]
        public string ZHNR { get; set; }

        [JsonProperty("ZHAMDR")]
        public string ZHAMDR { get; set; }

        [JsonProperty("ZHAMCR")]
        public string ZHAMCR { get; set; }

        [JsonProperty("ZHBALD")]
        public string ZHBALD { get; set; }

        [JsonProperty("ZHRBAL")]
        public string ZHRBAL { get; set; }

        [JsonProperty("ZHAB")]
        public string ZHAB { get; set; }

        [JsonProperty("ZHAN")]
        public string ZHAN { get; set; }

        [JsonProperty("ZHAS")]
        public string ZHAS { get; set; }

        [JsonProperty("ZHACZ")]
        public string ZHACZ { get; set; }

        [JsonProperty("ZHPOD")]
        public string ZHPOD { get; set; }

        [JsonProperty("ZHPSQ")]
        public string ZHPSQ { get; set; }

        [JsonProperty("ZHNAR2")]
        public string ZHNAR2 { get; set; }

        [JsonProperty("ZHNAR3")]
        public string ZHNAR3 { get; set; }

        [JsonProperty("ZHNAR4")]
        public string ZHNAR4 { get; set; }
    }
}
