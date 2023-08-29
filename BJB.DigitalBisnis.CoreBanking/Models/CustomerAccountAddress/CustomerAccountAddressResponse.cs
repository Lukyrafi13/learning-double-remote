using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.CustomerAccountAddress
{

    public class MPOCustomerAccountAddressResponse
    {
        [JsonProperty("0")]
        public MPOCustomerAccountAddressResponseDetail MPOCustomerAccountAddressResponseDetail { get; set; }
    }

    public class MPOCustomerAccountAddressResponseDetail
    {
        [JsonProperty("ZLAB")]
        public string ZLAB { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("ZLAS")]
        public string ZLAS { get; set; }

        [JsonProperty("ZLNA1")]
        public string ZLNA1 { get; set; }

        [JsonProperty("ZLNA2")]
        public string ZLNA2 { get; set; }

        [JsonProperty("ZLNA3")]
        public string ZLNA3 { get; set; }

        [JsonProperty("ZLNA4")]
        public string ZLNA4 { get; set; }

        [JsonProperty("ZLNA5")]
        public string ZLNA5 { get; set; }

        [JsonProperty("ZLPZIP")]
        public string ZLPZIP { get; set; }

        [JsonProperty("ZLLNM")]
        public string ZLLNM { get; set; }

        [JsonProperty("ZLPHN")]
        public string ZLPHN { get; set; }

        [JsonProperty("ZLCSA")]
        public string ZLCSA { get; set; }

        [JsonProperty("ZLEANE")]
        public string ZLEANE { get; set; }

        [JsonProperty("ZLSNPR")]
        public string ZLSNPR { get; set; }

        [JsonProperty("ZLLAN")]
        public string ZLLAN { get; set; }
    }
}
