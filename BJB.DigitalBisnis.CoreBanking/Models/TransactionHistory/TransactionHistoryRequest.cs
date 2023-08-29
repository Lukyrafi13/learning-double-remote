using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.TransactionHistory
{
    public class TransactionHistoryRequest
    {
        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }
    }
}
