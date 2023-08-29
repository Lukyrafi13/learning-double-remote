using System;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.DigiloanAPI.Models
{
	public class SendResultDisbursementResponseModel
	{
        [JsonPropertyName("data")]
        public List<SendDocumentRequestModel> data { get; set; }

        [JsonPropertyName("errors")]
        public List<string> errors { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }

        [JsonPropertyName("meta")]
        public Meta meta { get; set; }

        [JsonPropertyName("statusCode")]
        public int statusCode { get; set; }
    }
}

