using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.CoreBanking.Models
{
    public class BaseCoreBankingRequest<T>
    {
        [JsonProperty("PCC")]
        public string PCC { get; set; }

        [JsonProperty("FC")]
        public string FC { get; set; }

        [JsonProperty("DT")]
        public string DT { get; set; }

        [JsonProperty("AUDITUID")]
        public string AUDITUID { get; set; }

        [JsonProperty("MT")]
        public string MT { get; set; }
        /// <summary>
        /// Chanell Id
        /// </summary>

        [JsonProperty("CID")]
        public string CID { get; set; }

        [JsonProperty("SID")]
        public string SID { get; set; }

        [JsonProperty("ST")]
        public string ST { get; set; }

        [JsonProperty("MPI")]
        public T MPI { get; set; }

        [JsonProperty("CC")]
        public string CC { get; set; }

        [JsonProperty("REMOTEIP")]
        public string REMOTEIP { get; set; }

        [JsonProperty("SPPW")]
        public string SPPW { get; set; }

        [JsonProperty("MC")]
        public string MC { get; set; } = "90023";

        [JsonProperty("SPPU")]
        public string SPPU { get; set; }

        [JsonProperty("PC")]
        public string PC { get; set; }
        [JsonProperty("BRANCHCD")]
        public string BRANCHCD { get; set; }

    }
}
