using System.Text.Json.Serialization;

namespace NewLMS.UMKM.SIKP2.Models
{
    public class RateAkadResponseModel
    {
        [JsonPropertyName("error")]
        public bool error { get; set; }
        [JsonPropertyName("code")]
        public string code { get; set; }
        public string code_inquiry_calon { get; set; }
        [JsonPropertyName("status_code")]
        public int status_code { get; set; }
        [JsonPropertyName("message")]
        public string message { get; set; }
        [JsonPropertyName("data")]
        public List<DetailRateAkadResponseModel> data { get; set; }
    }
    public class DetailRateAkadResponseModel
    {
        [JsonPropertyName("nik")]
        public string nik { get; set; }
        [JsonPropertyName("skema")]
        public string skema { get; set; }
        [JsonPropertyName("total_limit_default")]
        public string total_limit_default { get; set; }
        [JsonPropertyName("total_limit")]
        public string total_limit { get; set; }
        [JsonPropertyName("limit_aktif_default")]
        public string limit_aktif_default { get; set; }
        [JsonPropertyName("limit_aktif")]
        public string limit_aktif { get; set; }
        [JsonPropertyName("count_akad")]
        public string count_akad { get; set; }
        [JsonPropertyName("kode_bank")]
        public string kode_bank { get; set; }
        [JsonPropertyName("sisa_akad")]
        public int sisa_akad { get; set; }
        [JsonPropertyName("max_akad")]
        public int max_akad { get; set; }
        [JsonPropertyName("rate")]
        public double rate { get; set; }
        public int sisaWaktuBooking { get; set; }
        public int sisaHari { get; set; }
    }
}
