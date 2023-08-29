using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AccountBalanceEnquiry
{

    public class MPOAccountBalanceEnquiry
    {
        [JsonProperty("0")]
        public MPOAccountBalanceEnquiryDetail mPOAccountBalanceEnquiryDetail { get; set; }
    }

    public class MPOAccountBalanceEnquiryDetail
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

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLCUR")]
        public string ZLCUR { get; set; }

        [JsonProperty("ZLCL01")]
        public string ZLCL01 { get; set; }

        [JsonProperty("ZLDT02")]
        public string ZLDT02 { get; set; }

        [JsonProperty("ZLDS02")]
        public string ZLDS02 { get; set; }

        [JsonProperty("ZLBM02")]
        public string ZLBM02 { get; set; }

        [JsonProperty("ZLCL02")]
        public string ZLCL02 { get; set; }

        [JsonProperty("ZLDT03")]
        public string ZLDT03 { get; set; }

        [JsonProperty("ZLDS03")]
        public string ZLDS03 { get; set; }

        [JsonProperty("ZLDT04")]
        public string ZLDT04 { get; set; }

        [JsonProperty("ZLDS04")]
        public string ZLDS04 { get; set; }

        [JsonProperty("ZLBM04")]
        public string ZLBM04 { get; set; }

        [JsonProperty("ZLCL04")]
        public string ZLCL04 { get; set; }

        [JsonProperty("ZLDAT")]
        public string ZLDAT { get; set; }

        [JsonProperty("ZLDSC")]
        public string ZLDSC { get; set; }

        [JsonProperty("ZLBAL")]
        public string ZLBAL { get; set; }

        [JsonProperty("ZLDSS1")]
        public string ZLDSS1 { get; set; }

        [JsonProperty("ZLBMT1")]
        public string ZLBMT1 { get; set; }

        [JsonProperty("ZLDSS2")]
        public string ZLDSS2 { get; set; }

        [JsonProperty("ZLDSS3")]
        public string ZLDSS3 { get; set; }

        [JsonProperty("ZLBMT3")]
        public string ZLBMT3 { get; set; }

        [JsonProperty("ZLBMT5")]
        public string ZLBMT5 { get; set; }
    }

}
