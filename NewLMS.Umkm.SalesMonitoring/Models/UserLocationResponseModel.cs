using System.Text.Json.Serialization;

namespace NewLMS.Umkm.Maps.Models
{
    public class UserLocationResponseModel
    {
        [JsonPropertyName("message")]
        public string message { get; set; }
        [JsonPropertyName("data")]
        public Data data { get; set; }
    }
    public class Data
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("code")]
        public string code { get; set; }
        [JsonPropertyName("content")]
        public string content { get; set; }
        [JsonPropertyName("lat")]
        public string lat { get; set; }
        [JsonPropertyName("long")]
        public string @long { get; set; }
        [JsonPropertyName("category")]
        public string category { get; set; }
        [JsonPropertyName("source_app")]
        public string source_app { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime updatedAt { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime createdAt { get; set; }
    }
}
