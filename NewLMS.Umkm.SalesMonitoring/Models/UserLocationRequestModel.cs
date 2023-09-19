using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Maps.Models
{
    public class UserLocationRequestModel
    {
        [JsonPropertyName("code")]
        public string code { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("lat")]
        public string lat { get; set; }
        [JsonPropertyName("long")]
        public string @long { get; set; }
        [JsonPropertyName("category")]
        public string category { get; set; }
        [JsonPropertyName("source_app")]
        public string source_app { get; set; }
        [JsonPropertyName("branch_id")]
        public string branch_id { get; set; }
    }

    public class UserLocationContentRequestModel
    {
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string NIP { get; set; }
        public string Grade { get; set; }
        public List<ProspectRequestModel> Prospects { get; set; }
        public List<IDERequestModel> IDEs { get; set; }
    }

    public class ProspectRequestModel
    {
        public string ProspectNo { get; set; }
        public DateTime ProspectDate { get; set; }
        public int Aging { get; set; }
        public string Debtor { get; set; }
        public double? Plafond { get; set; }
    }

    public class IDERequestModel
    {
        public string ProspectNo { get; set; }
        public DateTime ProspectDate { get; set; }
        public int Aging { get; set; }
        public string Debtor { get; set; }
        public double? Plafond { get; set; }
    }

}
