using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.DigiloanAPI.Models
{
    public class SendDocumentResponseModel
    {
        [JsonPropertyName("data")]
        public List<Datum> data { get; set; }

        [JsonPropertyName("errors")]
        public List<string> errors { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }

        [JsonPropertyName("meta")]
        public Meta meta { get; set; }

        [JsonPropertyName("statusCode")]
        public int statusCode { get; set; }
    }
    public class Datum
    {
        [JsonPropertyName("lmsappid")]
        public string lmsappid { get; set; }

        [JsonPropertyName("documentUrl")]
        public DocumentUrl documentUrl { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("currentPage")]
        public int currentPage { get; set; }

        [JsonPropertyName("firstPage")]
        public int firstPage { get; set; }

        [JsonPropertyName("lastPage")]
        public int lastPage { get; set; }

        [JsonPropertyName("perPage")]
        public int perPage { get; set; }

        [JsonPropertyName("totalPage")]
        public int totalPage { get; set; }

        [JsonPropertyName("total")]
        public int total { get; set; }
    }


}
