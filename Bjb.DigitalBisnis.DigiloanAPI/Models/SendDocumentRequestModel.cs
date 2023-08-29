using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.DigiloanAPI.Models
{
    public class SendDocumentRequestModel
    {
        [JsonPropertyName("lmsappid")]
        public string lmsappid { get; set; }

        [JsonPropertyName("documentUrl")]
        public DocumentUrl documentUrl { get; set; }
    }

    public class DocumentUrl
    {
        [JsonPropertyName("sp2k_url")]
        public string sp2k_url { get; set; }

        [JsonPropertyName("mak_url")]
        public string mak_url { get; set; }

        [JsonPropertyName("pk_url")]
        public string pk_url { get; set; }
    }
}
