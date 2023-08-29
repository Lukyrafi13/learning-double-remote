using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountList
{
    public class AccountListRequest
    {
        [JsonProperty("CIF")]
        public string CIF { get; set; }
    }
}
