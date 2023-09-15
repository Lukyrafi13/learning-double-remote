using System.Text.Json.Serialization;

namespace NewLMS.Umkm.SIKP.Models
{
    public class PostCalonDebiturResponseModelHeader
    {
        [JsonPropertyName("isSuccessStatusCode")]
        public bool isSuccessStatusCode { get; set; }
        [JsonPropertyName("statusCode")]
        public int? statusCode { get; set; }
        [JsonPropertyName("message")]
        public string? message { get; set; }
        [JsonPropertyName("error")]
        public string? error { get; set; }
        [JsonPropertyName("data")]
        public PostCalonDebiturResponseModel? data { get; set; }
    }
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