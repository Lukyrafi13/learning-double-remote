using Bjb.DigitalBisnis.CoreBanking.Models.AdditionalInformationEnquiry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InputAccountHold
{

    public class MPOInputAccountHoldResponse
    {
        [JsonProperty("0")]
        public MPOInputAccountHoldResponseDetail mPoInputAccountHoldResponseDetail { get; set; }
    }

    public class MPOInputAccountHoldResponseDetail
    {
        [JsonProperty("ZLBBN")]
        public string ZLBBN { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLCPNC")]
        public string ZLCPNC { get; set; }

        [JsonProperty("ZLCPNS")]
        public string ZLCPNS { get; set; }

        [JsonProperty("ZLSDTZ")]
        public string ZLSDTZ { get; set; }

        [JsonProperty("ZLAMT")]
        public string ZLAMT { get; set; }

        [JsonProperty("ZLACO")]
        public string ZLACO { get; set; }

        [JsonProperty("ZLHRC")]
        public string ZLHRC { get; set; }

        [JsonProperty("ZLHDD1")]
        public string ZLHDD1 { get; set; }

        [JsonProperty("ZLHDD2")]
        public string ZLHDD2 { get; set; }

        [JsonProperty("ZLHDD3")]
        public string ZLHDD3 { get; set; }

        [JsonProperty("ZLHDD4")]
        public string ZLHDD4 { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLCUS2")]
        public string ZLCUS2 { get; set; }

        [JsonProperty("ZLCUN2")]
        public string ZLCUN2 { get; set; }

        [JsonProperty("ZLBRM2")]
        public string ZLBRM2 { get; set; }

        [JsonProperty("ZLBRN2")]
        public string ZLBRN2 { get; set; }

        [JsonProperty("ZLEANE")]
        public string ZLEANE { get; set; }

        [JsonProperty("ZLSHN2")]
        public string ZLSHN2 { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLCUR")]
        public string ZLCUR { get; set; }

        [JsonProperty("ZLATP")]
        public string ZLATP { get; set; }

        [JsonProperty("ZLEATP")]
        public string ZLEATP { get; set; }

        [JsonProperty("ZLHNO")]
        public string ZLHNO { get; set; }

        [JsonProperty("ZLSDTE")]
        public string ZLSDTE { get; set; }

        [JsonProperty("ZLEDTE")]
        public string ZLEDTE { get; set; }

        [JsonProperty("ZLAMTE")]
        public string ZLAMTE { get; set; }

        [JsonProperty("ZLACOE")]
        public string ZLACOE { get; set; }

        [JsonProperty("ZLHRCE")]
        public string ZLHRCE
        {
            get; set;
        }
    }

}
