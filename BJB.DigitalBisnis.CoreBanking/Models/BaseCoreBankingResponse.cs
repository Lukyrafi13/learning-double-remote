using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models
{
    public class BaseCoreBankingResponse<T1, T2> where T1 : class where T2 : class
    {
        [JsonProperty("CC")]
        public string CC { get; set; }

        [JsonProperty("ST")]
        public string ST { get; set; }

        [JsonProperty("MPI")]
        public T1 MPI { get; set; }

        [JsonProperty("MT")]
        public string MT { get; set; }

        [JsonProperty("MPO")]
        public T2 MPO { get; set; }

        [JsonProperty("RCMSG")]
        public RCMSG RCMSG { get; set; }

        [JsonProperty("PCC")]
        public string PCC { get; set; }

        [JsonProperty("DT")]
        public string DT { get; set; }

        [JsonProperty("SID")]
        public string SID { get; set; }

        [JsonProperty("RC")]
        public string RC { get; set; }

        [JsonProperty("PC")]
        public string PC { get; set; }

        [JsonProperty("AUDITUID")]
        public string AUDITUID { get; set; }

        [JsonProperty("MC")]
        public string MC { get; set; }

        [JsonProperty("FC")]
        public string FC { get; set; }

        [JsonProperty("CID")]
        public string CID { get; set; }
    }

    public class RCMSG
    {
        [JsonProperty("0")]
        public _0 _0 { get; set; }
    }

    public class _0
    {
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
