using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.OpenCustomerAccount
{

    public class MPOCustomerAccountResponse

    {
        [JsonProperty("0")]
        public MPOCustomerAccountResponseDetail MPOCustomerAccountResponseDetail { get; set; }
    }

    public class MPOCustomerAccountResponseDetail
    {
        [JsonProperty("ZLAB")]
        public string ZLAB { get; set; }

        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("ZLAS")]
        public string ZLAS { get; set; }

        [JsonProperty("ZLACT")]
        public string ZLACT { get; set; }

        [JsonProperty("ZLSHN")]
        public string ZLSHN { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLJAC")]
        public string ZLJAC { get; set; }

        [JsonProperty("ZLEACT")]
        public string ZLEACT { get; set; }

        [JsonProperty("ZLCUS2")]
        public string ZLCUS2 { get; set; }

        [JsonProperty("ZLCUN2")]
        public string ZLCUN2 { get; set; }

        [JsonProperty("ZLACCZ")]
        public string ZLACCZ { get; set; }

        [JsonProperty("ZLECCY")]
        public string ZLECCY { get; set; }

        [JsonProperty("ZLEOAD")]
        public string ZLEOAD { get; set; }

        [JsonProperty("CHS01")]
        public string CHS01 { get; set; }
    }
}
