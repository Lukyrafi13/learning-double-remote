using System.Text.Json.Serialization;

namespace NewLMS.Umkm.SIKP.Models
{
    public class PlafonResponseModel
    {
        [JsonPropertyName("error")]
        public bool error { get; set; }
        [JsonPropertyName("code")]
        public string? code { get; set; }
        [JsonPropertyName("status_code")]
        public string? status_code { get; set; }
        [JsonPropertyName("message")]
        public string? message { get; set; }
        [JsonPropertyName("data")]
        public List<DetailLimitAkadResponseModel>? data { get; set; }
    }
}
