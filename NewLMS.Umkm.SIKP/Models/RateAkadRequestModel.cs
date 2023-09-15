using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewLMS.Umkm.SIKP.Models
{
    public class RateAkadRequestModel
    {
        [JsonPropertyName("nik")]
        public string nik { get; set; }
        [JsonPropertyName("sektor")]
        public string sektor { get; set; }
    }
}
