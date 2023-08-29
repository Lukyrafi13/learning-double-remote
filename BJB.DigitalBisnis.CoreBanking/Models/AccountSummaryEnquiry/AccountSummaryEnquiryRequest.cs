using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountSummaryEnquiry
{
    public class AccountSummaryEnquiryRequest
    {
        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("PGNUM")]
        public string PGNUM { get; set; }

        [JsonProperty("PGSIZE")]
        public string PGSIZE { get; set; }
    }
}
