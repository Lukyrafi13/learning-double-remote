using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountList
{
    public class MPOAccountListResponse
    {
        [JsonProperty("0")]
        public MPOAccountListResponseDetail MPOAccountListResponseDetail { get; set; }
    }
    public class MPOAccountListResponseDetail
    {
        [JsonProperty("CIF")]
        public string CIF { get; set; }

        [JsonProperty("RESULT1")]
        public string RESULT1 { get; set; }

        [JsonProperty("RESULT2")]
        public string RESULT2 { get; set; }

    }
}
