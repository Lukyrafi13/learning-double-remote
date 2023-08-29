using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.TransactionHistory
{
    public class MPOTransactionHistoryResponse
    {
        [JsonProperty("0")]
        public MPOTransactionHistoryResponseDetail MPOTransactionHistoryResponseDetail { get; set; }
    }
    public class MPOTransactionHistoryResponseDetail
    {
        [JsonProperty("ZLOUT")]
        public string ZLOUT { get; set; }

        [JsonProperty("IS_OVERRIDE")]
        public string ISOVERRIDE { get; set; }

        [JsonProperty("AUTHORITY")]
        public string AUTHORITY { get; set; }

        [JsonProperty("MESSAGE_ID")]
        public string MESSAGEID { get; set; }

        [JsonProperty("FIELD_IN_ERROR")]
        public string FIELDINERROR { get; set; }

        [JsonProperty("SEVERITY_STATUS")]
        public string SEVERITYSTATUS { get; set; }

        [JsonProperty("MESSAGE")]
        public string MESSAGE { get; set; }

        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        [JsonProperty("SEVERITY")]
        public string SEVERITY { get; set; }
    }

}
