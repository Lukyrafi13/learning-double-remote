using System.Text.Json.Serialization;

namespace NewLMS.UMKM.SIKP.Models
{
    public class PostCalonDebiturRequestModel
    {
        public string nik {get; set;}
        public string nmr_registry {get; set;}
        public string nama {get; set;}
        public string tgl_lahir {get; set;}
        public string jns_kelamin {get; set;}
        public string maritas_sts {get; set;}
        public string pendidikan {get; set;}
        public string pekerjaan {get; set;}
        public string alamat {get; set;}
        public string kode_kabkota {get; set;}
        public string kode_pos {get; set;}
        public string npwp {get; set;}
        public string mulai_usaha {get; set;}
        public string alamat_usaha {get; set;}
        public string ijin_usaha {get; set;}
        public string modal_usaha {get; set;}
        public string jml_pekerja {get; set;}
        public string jml_kredit {get; set;}
        public string is_linkage {get; set;}
        public string linkage {get; set;}
        public string no_hp {get; set;}
        public string uraian_agunan {get; set;}
        public string is_subsidized {get; set;}
        public string subsidi_sebelumnya {get; set;}
    }
}