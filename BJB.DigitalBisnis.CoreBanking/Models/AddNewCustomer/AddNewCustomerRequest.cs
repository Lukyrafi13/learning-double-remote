using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AddNewCustomer
{
    public class AddNewCustomerRequest
    {
        /// <summary>
        /// CLS Type
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLCTP")]
        public string ZLCTP { get; set; }
        /// <summary>
        /// Customer basic number
        /// </summary>

        [JsonProperty("ZLCPNC")]
        [MaxLength(6)]
        public string ZLCPNC { get; set; }
        /// <summary>
        /// Customer full name
        /// </summary>

        [JsonProperty("ZLCUN")]
        [MaxLength(35)]
        public string ZLCUN { get; set; }
        /// <summary>
        /// Default A/C short name
        /// </summary>

        [JsonProperty("ZLDAS")]
        [MaxLength(15)]
        public string ZLDAS { get; set; }
        /// <summary>
        /// Default branch
        /// </summary>

        [JsonProperty("ZLBRNM")]
        [MaxLength(4)]
        public string ZLBRNM { get; set; }
        /// <summary>
        /// Blocked for deal input
        /// </summary>

        [JsonProperty("ZLCUB")]
        [MaxLength(1)]
        public string ZLCUB { get; set; }
        /// <summary>
        /// Default tax references
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLCRB1")]

        public string ZLCRB1 { get; set; }
        /// <summary>
        /// Default tax references
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLCRB2")]
        public string ZLCRB2 { get; set; }
        /// <summary>
        /// Parent country
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLCNAP")]
        public string ZLCNAP { get; set; }
        /// <summary>
        /// Residence country
        /// </summary>
        [MaxLength(2)]

        [JsonProperty("ZLCNAL")]
        public string ZLCNAL { get; set; }
        /// <summary>
        /// Deceased/liquidated
        /// </summary>
        /// 
        [MaxLength(1)]
        [JsonProperty("ZLCUD")]
        public string ZLCUD { get; set; }
        /// <summary>
        /// Closed
        /// </summary>
        /// 
        [MaxLength(1)]
        [JsonProperty("ZLCUC")]
        public string ZLCUC { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>

        [MaxLength(1)]
        [JsonProperty("ZLCUZ")]
        public string ZLCUZ { get; set; }
        /// <summary>
        /// Account officer
        /// </summary>

        [MaxLength(3)]
        [JsonProperty("ZLACO")]
        public string ZLACO { get; set; }
        /// <summary>
        /// Risk country
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLCNAR")]
        public string ZLCNAR { get; set; }
        /// <summary>
        /// Internal risk country
        /// </summary>
        [MaxLength(2)]

        [JsonProperty("ZLCNAI")]
        public string ZLCNAI { get; set; }
        /// <summary>
        /// Language
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("ZLLNM")]
        public string ZLLNM { get; set; }
        /// <summary>
        /// Mail to branch
        /// </summary>
        [MaxLength(4)]
        [JsonProperty("ZLMTB")]
        public string ZLMTB { get; set; }
        /// <summary>
        /// Exempt from TF taxes
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLYETX")]
        public string ZLYETX { get; set; }
        /// <summary>
        /// Copy stmt special address
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLCSSA")]
        public string ZLCSSA { get; set; }
        /// <summary>
        /// Force cycle statement
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLFCYC")]
        public string ZLFCYC { get; set; }
        /// <summary>
        /// Consolidated statements
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLCS")]
        public string ZLCS { get; set; }
        /// <summary>
        /// Front Office
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLDRCZ")]
        public string ZLDRCZ { get; set; }
        /// <summary>
        /// Retail branch
        /// </summary>
        [MaxLength(1)]

        [JsonProperty("ZLRETZ")]
        public string ZLRETZ { get; set; }
        /// <summary>
        /// Retail branch
        /// </summary>
        [MaxLength(1)]
        [JsonProperty("ZLTRIZ")]
        public string ZLTRIZ { get; set; }
    }
}
