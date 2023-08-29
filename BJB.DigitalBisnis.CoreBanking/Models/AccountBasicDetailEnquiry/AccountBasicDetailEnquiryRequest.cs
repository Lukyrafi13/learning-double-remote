using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountBasicDetailEnquiry
{
    public class AccountBasicDetailEnquiryRequest
    {
        /// <summary>
        /// Account
        /// <br/>Max character 20
        /// </summary>
        [JsonProperty("ZLEAN")]
        [MaxLength(20)]
        public string ZLean { get; set; }
    }
}
