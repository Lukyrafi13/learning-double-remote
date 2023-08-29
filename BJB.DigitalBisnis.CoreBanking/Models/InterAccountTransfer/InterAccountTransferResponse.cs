using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.InterAccountTransfer
{
    public class MPOInterAccountTransfer
    {
        [JsonProperty("0")]
        public MPOInterAccountTransferDetail mPOInterAccountTransferDetail { get; set; }
    }

    public class MPOInterAccountTransferDetail
    {
        [JsonProperty("ZLREF")]
        public string ZLREF { get; set; }

        [JsonProperty("ZLAB1")]
        public string ZLAB1 { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLAN1")]
        public string ZLAN1 { get; set; }

        [JsonProperty("ZLAS1")]
        public string ZLAS1 { get; set; }

        [JsonProperty("ZLAB2")]
        public string ZLAB2 { get; set; }

        [JsonProperty("ZLEAN1")]
        public string ZLEAN1 { get; set; }

        [JsonProperty("ZLAN2")]
        public string ZLAN2 { get; set; }

        [JsonProperty("ZLAS2")]
        public string ZLAS2 { get; set; }

        [JsonProperty("ZLTCD1")]
        public string ZLTCD1 { get; set; }

        [JsonProperty("ZLAMZ1")]
        public string ZLAMZ1 { get; set; }

        [JsonProperty("ZLVFZ1")]
        public string ZLVFZ1 { get; set; }

        [JsonProperty("ZLDRF1")]
        public string ZLDRF1 { get; set; }

        [JsonProperty("ZLNR1")]
        public string ZLNR1 { get; set; }

        [JsonProperty("ZLNR2")]
        public string ZLNR2 { get; set; }

        [JsonProperty("ZLNR3")]
        public string ZLNR3 { get; set; }

        [JsonProperty("ZLNR4")]
        public string ZLNR4 { get; set; }

        [JsonProperty("ZLTCD2")]
        public string ZLTCD2 { get; set; }

        [JsonProperty("ZLAMZ2")]
        public string ZLAMZ2 { get; set; }

        [JsonProperty("ZLVFZ2")]
        public string ZLVFZ2 { get; set; }

        [JsonProperty("ZLDRF2")]
        public string ZLDRF2 { get; set; }

        [JsonProperty("ZLNR5")]
        public string ZLNR5 { get; set; }

        [JsonProperty("ZLNR6")]
        public string ZLNR6 { get; set; }

        [JsonProperty("ZLNR7")]
        public string ZLNR7 { get; set; }

        [JsonProperty("ZLNR8")]
        public string ZLNR8 { get; set; }

        [JsonProperty("ZLSHN1")]
        public string ZLSHN1 { get; set; }

        [JsonProperty("ZLSHN2")]
        public string ZLSHN2 { get; set; }

        [JsonProperty("ZLEAND")]
        public string ZLEAND { get; set; }

        [JsonProperty("ZLTCN1")]
        public string ZLTCN1 { get; set; }

        [JsonProperty("ZLCCY1")]
        public string ZLCCY1 { get; set; }

        [JsonProperty("ZLCUR1")]
        public string ZLCUR1 { get; set; }

        [JsonProperty("ZLAM1E")]
        public string ZLAM1E { get; set; }

        [JsonProperty("ZLVFE1")]
        public string ZLVFE1 { get; set; }

        [JsonProperty("ZHDRF")]
        public string ZHDRF { get; set; }

        [JsonProperty("ZHNR1")]
        public string ZHNR1 { get; set; }

        [JsonProperty("ZHNR2")]
        public string ZHNR2 { get; set; }

        [JsonProperty("ZHNR3")]
        public string ZHNR3 { get; set; }

        [JsonProperty("ZHNR4")]
        public string ZHNR4 { get; set; }

        [JsonProperty("ZLEANC")]
        public string ZLEANC { get; set; }

        [JsonProperty("ZLTCN2")]
        public string ZLTCN2 { get; set; }

        [JsonProperty("ZLCCY2")]
        public string ZLCCY2 { get; set; }

        [JsonProperty("ZLCUR2")]
        public string ZLCUR2 { get; set; }

        [JsonProperty("ZLAM2E")]
        public string ZLAM2E { get; set; }

        [JsonProperty("ZLVFE2")]
        public string ZLVFE2 { get; set; }

        [JsonProperty("ZHNR5")]
        public string ZHNR5 { get; set; }

        [JsonProperty("ZHNR6")]
        public string ZHNR6 { get; set; }

        [JsonProperty("ZHNR7")]
        public string ZHNR7 { get; set; }

        [JsonProperty("ZHNR8")]
        public string ZHNR8 { get; set; }
    }
}
