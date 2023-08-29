using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bjb.DigitalBisnis.CoreBanking.Models.EA
{
    public class EARequest
    {
        [JsonProperty("ZLEANC")]
        public string ZLEANC { get; set; }

        [JsonProperty("PGSIZE")]
        public string PGSIZE { get; set; } = "1";

        [JsonProperty("PGNUM")]
        public string PGNUM { get; set; } = "1";
    }
}