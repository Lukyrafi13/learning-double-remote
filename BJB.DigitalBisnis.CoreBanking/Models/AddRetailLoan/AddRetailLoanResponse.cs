using Bjb.DigitalBisnis.CoreBanking.Models.AccountTransactionHistory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models.AddRetailLoan
{
    public class MPOAddRetailLoanResponse
    {
        [JsonProperty("0")]
        public MPOAddRetailLoanResponseDetail MPOAddRetailLoanResponseDetail { get; set; }
    }
    public class MPOAddRetailLoanResponseDetail
    {
        [JsonProperty("ZLLNP")]
        public string ZLLNP { get; set; }

        [JsonProperty("ZLLNR")]
        public string ZLLNR { get; set; }

        [JsonProperty("ZLBRNM")]
        public string ZLBRNM { get; set; }

        [JsonProperty("ZLCPNC")]
        public object ZLCPNC { get; set; }

        [JsonProperty("ZLCCY")]
        public string ZLCCY { get; set; }

        [JsonProperty("ZLDLAZ")]
        public string ZLDLAZ { get; set; }

        [JsonProperty("ZLOPAZ")]
        public string ZLOPAZ { get; set; }

        [JsonProperty("ZLCLT")]
        public string ZLCLT { get; set; }

        [JsonProperty("ZLRTMZ")]
        public string ZLRTMZ { get; set; }

        [JsonProperty("ZLPEGZ")]
        public string ZLPEGZ { get; set; }

        [JsonProperty("ZLIDB")]
        public string ZLIDB { get; set; }

        [JsonProperty("ZLCPIZ")]
        public string ZLCPIC { get; set; }

        [JsonProperty("ZLPRPZ")]
        public string ZLPRPZ { get; set; }

        [JsonProperty("ZLRPYM")]
        public string ZLRPYM { get; set; }

        [JsonProperty("ZLDDC")]
        public string ZLDDC { get; set; }

        [JsonProperty("ZLSCHC")]
        public string ZLSCHC { get; set; }

        [JsonProperty("ZLNPYA")]
        public string ZLNPYA { get; set; }

        [JsonProperty("ZLRPQ")]
        public string ZLRPQ { get; set; }

        [JsonProperty("ZLRPAZ")]
        public string ZLRPAZ { get; set; }

        [JsonProperty("ZLFDTZ")]
        public object ZLFDTZ { get; set; }

        [JsonProperty("ZLDIF")]
        public string ZLDIF { get; set; }

        [JsonProperty("ZLAB")]
        public string ZLAB { get; set; }

        [JsonProperty("ZLEAN")]
        public string ZLEAN { get; set; }

        [JsonProperty("ZLAN")]
        public string ZLAN { get; set; }

        [JsonProperty("ZLAS")]
        public string ZLAS { get; set; }

        [JsonProperty("ZLCCYR")]
        public string ZLCCYR { get; set; }

        [JsonProperty("ZLCCYP")]
        public string ZLCCYP { get; set; }

        [JsonProperty("ZLCCYI")]
        public string ZLCCYI { get; set; }

        [JsonProperty("ZLSAPZ")]
        public string ZLSAPZ { get; set; }

        [JsonProperty("ZLNDAZ")]
        public string ZLNDAZ { get; set; }

        [JsonProperty("ZLLPD")]
        public string ZLLPD { get; set; }

        [JsonProperty("ZLBRN")]
        public string ZLBRN { get; set; }

        [JsonProperty("ZLCUN")]
        public object ZLCUN { get; set; }

        [JsonProperty("ZLCUR")]
        public string ZLCUR { get; set; }

        [JsonProperty("ZLDLAE")]
        public string ZLDLAE { get; set; }

        [JsonProperty("ZLSDTE")]
        public string ZLSDTE { get; set; }

        [JsonProperty("ZLCTDE")]
        public string ZLCDTE { get; set; }

        [JsonProperty("ZLOPAE")]
        public string ZLOPAE { get; set; }

        [JsonProperty("ZLOSDE")]
        public string ZLOSDE { get; set; }

        [JsonProperty("CHS27")]
        public string CHS27 { get; set; }

        [JsonProperty("ZLLNRZ")]
        public object ZLLNRZ { get; set; }

        [JsonProperty("ZLDRTE")]
        public object ZLDRTE { get; set; }

        [JsonProperty("CHS04")]
        public object CHS04 { get; set; }

        [JsonProperty("ZLIDBD")]
        public object ZLIBD { get; set; }

        [JsonProperty("CHS19")]
        public object CHS19 { get; set; }

        [JsonProperty("ZLRPYD")]
        public object ZLRPYD { get; set; }

        [JsonProperty("ZLSCHD")]
        public object ZLSCHD { get; set; }

        [JsonProperty("ZLRPQN")]
        public object ZLRPQN { get; set; }

        [JsonProperty("ZLRPAE")]
        public object ZLRPAE { get; set; }

        [JsonProperty("ZLFDTE")]
        public object ZLFDTE { get; set; }

        [JsonProperty("CHS33")]
        public object CHS33 { get; set; }

        [JsonProperty("ZLSN1Z")]
        public object ZLSN1Z { get; set; }

        [JsonProperty("CHS22")]
        public object CHS22 { get; set; }

        [JsonProperty("ZLPRTT")]
        public object ZLPRTT { get; set; }

        [JsonProperty("ZLPRTD")]
        public object ZLPRTD { get; set; }

        [JsonProperty("ZLIRTT")]
        public object ZLIRTT { get; set; }

        [JsonProperty("ZLIRTD")]
        public object ZLIRTD { get; set; }

        [JsonProperty("ZLPDRZ")]
        public object ZLPDRZ { get; set; }

        [JsonProperty("ZLIDRZ")]
        public object ZLIDRZ { get; set; }
    }
}
