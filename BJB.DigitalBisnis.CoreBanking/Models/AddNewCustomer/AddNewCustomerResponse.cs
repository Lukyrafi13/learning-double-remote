using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AddNewCustomer
{
    public class MPOAddNewCustomerResponse
    {
        [JsonProperty("0")]
        public MPOAddNewCustomerResponseDetail MPOAddNewCustomerResponseDetail { get; set; }
    }
    public class MPOAddNewCustomerResponseDetail
    {
        [JsonProperty("ZLCUS")]
        public string ZLCUS { get; set; }

        [JsonProperty("ZLCTP")]
        public string ZLCTP { get; set; }

        [JsonProperty("ZLCPNC")]
        public string ZLCPNC { get; set; }

        [JsonProperty("ZLCUN")]
        public string ZLCUN { get; set; }

        [JsonProperty("ZLDAS")]
        public string ZLDAS { get; set; }

        [JsonProperty("ZLBRNM")]
        public string ZLBRNM { get; set; }

        [JsonProperty("ZLCUB")]
        public string ZLCUB { get; set; }

        [JsonProperty("ZLCRB1")]
        public string ZLCRB1 { get; set; }

        [JsonProperty("ZLCRB2")]
        public string ZLCRB2 { get; set; }

        [JsonProperty("ZLCNAP")]
        public string ZLCNAP { get; set; }

        [JsonProperty("ZLCNAL")]
        public string ZLCNAL { get; set; }

        [JsonProperty("ZLCUD")]
        public string ZLCUD { get; set; }

        [JsonProperty("ZLCUC")]
        public string ZLCUC { get; set; }

        [JsonProperty("ZLCUZ")]
        public string ZLCUZ { get; set; }

        [JsonProperty("ZLACO")]
        public string ZLACO { get; set; }

        [JsonProperty("ZLCNAR")]
        public string ZLCNAR { get; set; }

        [JsonProperty("ZLCNAI")]
        public string ZLCNAI { get; set; }

        [JsonProperty("ZLLNM")]
        public string ZLLNM { get; set; }

        [JsonProperty("ZLMTB")]
        public string ZLMTB { get; set; }

        [JsonProperty("ZLYETX")]
        public string ZLYETX { get; set; }

        [JsonProperty("ZLCREF")]
        public string ZLCREF { get; set; }

        [JsonProperty("ZLTRIZ")]
        public string ZLTRIZ { get; set; }

        [JsonProperty("ZLRETZ")]
        public string ZLRETZ { get; set; }

        [JsonProperty("ZLDRCZ")]
        public string ZLDRCZ { get; set; }

        [JsonProperty("ZLCS")]
        public string ZLCS { get; set; }

        [JsonProperty("ZLFCYC")]
        public string ZLFCYC { get; set; }

        [JsonProperty("ZLCSSA")]
        public string ZLCSSA { get; set; }

        [JsonProperty("ZLFON")]
        public string ZLFON { get; set; }

        [JsonProperty("ZLFOL")]
        public string ZLFOL { get; set; }

        [JsonProperty("ZLCTD")]
        public string ZLCTD { get; set; }

        [JsonProperty("ZLBRN")]
        public string ZLBRN { get; set; }

        [JsonProperty("CHS09")]
        public string CHS09 { get; set; }

        [JsonProperty("ZLCNMP")]
        public string ZLCNMP { get; set; }

        [JsonProperty("ZLCNML")]
        public string ZLCNML { get; set; }

        [JsonProperty("CHS01")]
        public string CHS01 { get; set; }

        [JsonProperty("CHS02")]
        public string CHS02 { get; set; }

        [JsonProperty("CHS03")]
        public string CHS03 { get; set; }

        [JsonProperty("ZLRNM")]
        public string ZLRNM { get; set; }

        [JsonProperty("ZLCNMR")]
        public string ZLCNMR { get; set; }

        [JsonProperty("ZLCNMI")]
        public string ZLCNMI { get; set; }

        [JsonProperty("ZLLAN")]
        public string ZLLAN { get; set; }

        [JsonProperty("ZLMTBD")]
        public string ZLMTBD { get; set; }

        [JsonProperty("CHS10")]
        public string CHS10 { get; set; }

        [JsonProperty("CHS21")]
        public string CHS21 { get; set; }

        [JsonProperty("CHS22")]
        public string CHS22 { get; set; }

        [JsonProperty("CHS25")]
        public string CHS25 { get; set; }

        [JsonProperty("CHS31")]
        public string CHS31 { get; set; }

        [JsonProperty("CHS32")]
        public string CHS32 { get; set; }

        [JsonProperty("CHS33")]
        public string CHS33 { get; set; }
    }
}
