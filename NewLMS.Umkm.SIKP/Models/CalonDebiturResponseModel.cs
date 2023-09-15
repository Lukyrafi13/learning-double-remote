using System.Text.Json.Serialization;

namespace NewLMS.Umkm.SIKP.Models
{
    public class CalonDebiturResponseModelHeader
    {
        [JsonPropertyName("isSuccessStatusCode")]
        public bool isSuccessStatusCode { get; set; }
        [JsonPropertyName("statusCode")]
        public int? statusCode { get; set; }
        [JsonPropertyName("message")]
        public string? message { get; set; }
        [JsonPropertyName("error")]
        public string? error { get; set; }
        public CalonDebiturResponseModel? data { get; set; }
    }
    public class CalonDebiturResponseModel
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
        public DetailCalonDebiturResponseModel? data { get; set; }
    }
    public class DetailCalonDebiturResponseModel
    {
        [JsonPropertyName("nik")]
        public string? nik { get; set; }
        [JsonPropertyName("skema")]
        public string? skema { get; set; }
        [JsonPropertyName("nmr_registry")]
        public string? nmr_registry { get; set; }
        [JsonPropertyName("nama")]
        public string? nama { get; set; }
        [JsonPropertyName("tgl_lahir")]
        public string? tgl_lahir { get; set; }
        [JsonPropertyName("jns_kelamin")]
        public string? jns_kelamin { get; set; }
        [JsonPropertyName("maritas_sts")]
        public string? maritas_sts { get; set; }
        [JsonPropertyName("pendidikan")]
        public string? pendidikan { get; set; }
        [JsonPropertyName("pekerjaan")]
        public string? pekerjaan { get; set; }
        [JsonPropertyName("alamat")]
        public string? alamat { get; set; }
        [JsonPropertyName("kode_kabkota")]
        public string? kode_kabkota { get; set; }
        [JsonPropertyName("kode_pos")]
        public string? kode_pos { get; set; }
        [JsonPropertyName("npwp")]
        public string? npwp { get; set; }
        [JsonPropertyName("mulai_usaha")]
        public string? mulai_usaha { get; set; }
        [JsonPropertyName("alamat_usaha")]
        public string? alamat_usaha { get; set; }
        [JsonPropertyName("ijin_usaha")]
        public string? ijin_usaha { get; set; }
        [JsonPropertyName("modal_usaha")]
        public string? modal_usaha { get; set; }
        [JsonPropertyName("jml_pekerja")]
        public string? jml_pekerja { get; set; }
        [JsonPropertyName("jml_kredit")]
        public string? jml_kredit { get; set; }
        [JsonPropertyName("user_upload")]
        public string? user_upload { get; set; }
        [JsonPropertyName("tgl_upload")]
        public string? tgl_upload { get; set; }
        [JsonPropertyName("is_linkage")]
        public string? is_linkage { get; set; }
        [JsonPropertyName("no_hp")]
        public string? no_hp { get; set; }
        [JsonPropertyName("uraian_agunan")]
        public string? uraian_agunan { get; set; }
        [JsonPropertyName("is_subsidized")]
        public string? is_subsidized { get; set; }
        [JsonPropertyName("subsidi_sebelumnya")]
        public string? subsidi_sebelumnya { get; set; }
        [JsonPropertyName("is_debitur")]
        public string? is_debitur { get; set; }
        [JsonPropertyName("nama_file")]
        public string? nama_file { get; set; }
        [JsonPropertyName("is_api")]
        public string? is_api { get; set; }
        [JsonPropertyName("status_data")]
        public string? status_data { get; set; }
        [JsonPropertyName("kode_bank")]
        public string? kode_bank { get; set; }
        [JsonPropertyName("omset")]
        public string? omset { get; set; }
        [JsonPropertyName("skema_umi")]
        public string? skema_umi { get; set; }
        [JsonPropertyName("kondisi_rumah")]
        public string? kondisi_rumah { get; set; }
        [JsonPropertyName("updated_at")]
        public string? updated_at { get; set; }
        [JsonPropertyName("dukcapil")]
        public string? dukcapil { get; set; }
        [JsonPropertyName("is_uus")]
        public string? is_uus { get; set; }
        [JsonPropertyName("djp")]
        public string? djp { get; set; }
        [JsonPropertyName("sisa_waktu_book")]
        public string? sisa_waktu_book { get; set; }
        [JsonPropertyName("sisa_hari")]
        public string? sisa_hari { get; set; }
    }
}
