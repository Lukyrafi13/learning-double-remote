using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountTransactionHistory
{
    public class AccountTransactionHistoryRequest
    {
        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("PGNUM")]
        public string PGNUM { get; set; }

        [JsonProperty("PGSIZE")]
        public string PGSIZE { get; set; }
    }
}
