using System.Text.Json.Serialization;

namespace NewLMS.Umkm.SIKP.Models
{
    public class LimitAkadResponseModel
    {
        [JsonPropertyName("error")]
        public bool error { get; set; }
        [JsonPropertyName("code")]
        public string? code { get; set; }
        [JsonPropertyName("status_code")]
        public string? status_code { get; set; }
        [JsonPropertyName("message")]
        public string? message { get; set; }
        [JsonPropertyName("data")]
        public DetailLimitAkadResponseModel? data { get; set; }
    }
    public class DetailLimitAkadResponseModel
    {
        public string nik { get; set; }
        [JsonPropertyName("skema")]
        public string skema { get; set; }
        [JsonPropertyName("sektor")]
        public string sektor { get; set; }
        [JsonPropertyName("count_akad")]
        public string count_akad { get; set; }
        [JsonPropertyName("count_akad_ini")]
        public string count_akad_ini { get; set; }
        [JsonPropertyName("max_count_akad")]
        public string max_count_akad { get; set; }
        [JsonPropertyName("max_sum_akad")]
        public string max_sum_akad { get; set; }
        [JsonPropertyName("total_limit_default")]
        public string total_limit_default { get; set; }
        [JsonPropertyName("total_limit")]
        public string total_limit { get; set; }
        [JsonPropertyName("limit_aktif_default")]
        public string limit_aktif_default { get; set; }
        [JsonPropertyName("limit_aktif")]
        public string limit_aktif { get; set; }
        [JsonPropertyName("kode_bank")]
        public string kode_bank { get; set; }
    }
}
