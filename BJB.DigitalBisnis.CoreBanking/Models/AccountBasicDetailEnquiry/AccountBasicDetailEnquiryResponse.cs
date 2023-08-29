using Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountBasicDetailEnquiry
{

    public class MPOAccountBasicDetailEnquiry
    {
        [JsonProperty("0")]
        public MPOAccountBasicDetailEnquiryDetail mPOAccountBasicDetailEnquiryDetail { get; set; }
    }

    public class MPOAccountBasicDetailEnquiryDetail
    {
        [JsonProperty("ZLAB")]
        public string ZLAB { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("ZLAS")]
        public string ZLAS { get; set; }

        [JsonProperty("ZLCUS")]
        public string ZLCUS { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLCUN")]
        public string ZLCUN { get; set; }

        [JsonProperty("ZLEANE")]
        public string ZLEANE { get; set; }

        [JsonProperty("ZLACT")]
        public string ZLACT { get; set; }

        [JsonProperty("ZLATD")]
        public string ZLATD { get; set; }

        [JsonProperty("ZLBAL")]
        public string ZLBAL { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLACS")]
        public string ZLACS { get; set; }

        [JsonProperty("ZLASD")]
        public string ZLASD { get; set; }

        [JsonProperty("ZLCTP")]
        public string ZLCTP { get; set; }

        [JsonProperty("ZLCTD")]
        public string ZLCTD { get; set; }

        [JsonProperty("ZLCNAL")]
        public string ZLCNAL { get; set; }

        [JsonProperty("ZLCNML")]
        public string ZLCNML { get; set; }

        [JsonProperty("ZLACO")]
        public string ZLACO { get; set; }

        [JsonProperty("ZLRNM")]
        public string ZLRNM { get; set; }

        [JsonProperty("ZLCNAR")]
        public string ZLCNAR { get; set; }

        [JsonProperty("ZLCNMR")]
        public string ZLCNMR { get; set; }

        [JsonProperty("ZLLNM")]
        public string ZLLNM { get; set; }

        [JsonProperty("ZLLAN")]
        public string ZLLAN { get; set; }

        [JsonProperty("ZLDLM")]
        public string ZLDLM { get; set; }

        [JsonProperty("ZLOAD")]
        public string ZLOAD { get; set; }

        [JsonProperty("ZLDLE")]
        public string ZLDLE { get; set; }

        [JsonProperty("ZLNPEZ")]
        public string ZLNPEZ { get; set; }

        [JsonProperty("ZLSTNL")]
        public string ZLSTNL { get; set; }

        [JsonProperty("ZLBALS")]
        public string ZLBALS { get; set; }

        [JsonProperty("ZLCSTN")]
        public string ZLCSTN { get; set; }

        [JsonProperty("ZLC1RD")]
        public string ZLC1RD { get; set; }

        [JsonProperty("ZLC1R")]
        public string ZLC1R { get; set; }

        [JsonProperty("ZLC1D")]
        public string ZLC1D { get; set; }

        [JsonProperty("ZLC2RD")]
        public string ZLC2RD { get; set; }

        [JsonProperty("ZLC3RD")]
        public string ZLC3RD { get; set; }

        [JsonProperty("ZLC4RD")]
        public string ZLC4RD { get; set; }

        [JsonProperty("ZLC5RD")]
        public string ZLC5RD { get; set; }

        [JsonProperty("ZLP1RD")]
        public string ZLP1RD { get; set; }

        [JsonProperty("ZLP2RD")]
        public string ZLP2RD { get; set; }

        [JsonProperty("ZLP3RD")]
        public string ZLP3RD { get; set; }

        [JsonProperty("ZLP4RD")]
        public string ZLP4RD { get; set; }

        [JsonProperty("ZLP5RD")]
        public string ZLP5RD { get; set; }

        [JsonProperty("IS_OVERRIDE")]
        public string ISOVERRIDE { get; set; }

        [JsonProperty("AUTHORITY")]
        public string AUTHORITY { get; set; }

        [JsonProperty("MESSAGE_ID")]
        public string MESSAGEID { get; set; }

        [JsonProperty("FIELD_IN_ERROR")]
        public string FIELDINERROR { get; set; }

        [JsonProperty("SEVERITY_STATUS")]
        public string SEVERITYSTATUS { get; set; }

        [JsonProperty("MESSAGE")]
        public string MESSAGE { get; set; }

        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }

        [JsonProperty("SEVERITY")]
        public string SEVERITY { get; set; }
    }
}
