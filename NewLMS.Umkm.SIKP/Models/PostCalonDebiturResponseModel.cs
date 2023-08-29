using System.Text.Json.Serialization;

namespace NewLMS.Umkm.SIKP.Models
{
    public class PostCalonDebiturResponseModel
    {
        [JsonPropertyName("error")]
        public bool error { get; set; }
        [JsonPropertyName("code")]
        public string? code { get; set; }
        [JsonPropertyName("message")]
        public string? message { get; set; }
        [JsonPropertyName("nama")]
        public string? nama { get; set; }
    }
}