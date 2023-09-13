using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewLMS.UMKM.FileUpload.Models
{
    public class UploadResponseModel
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public Uri Data { get; set; }

        [JsonPropertyName("statusCode")]
        public long StatusCode { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
