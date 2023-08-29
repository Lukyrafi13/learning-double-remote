using System;
using System.Text.Json.Serialization;

namespace Bjb.DigitalBisnis.DigiloanAPI.Models
{
	public class SendResultDisbursementRequestModel
	{
        [JsonPropertyName("lmsappno")]
        public string LoanAppNo { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("proctime")]
        public DateTime ProcTime { get; set; }
	}
}

