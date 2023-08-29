using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry
{
    public class AccountBalanceEnquiryRequest
    {
        /// <summary>
        /// Account
        /// <br/>Max character 20
        /// </summary>
        [JsonProperty("ZLEAN")]
        [MaxLength(1)]
        public string ZLean { get; set; }
    }
}
