using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class SurveyBuyer : BaseEntity
    {
        public Guid Id { get; set; }        
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
        [ForeignKey("RFPaymentMethodsId")]
        public RFPaymentMethod MetodePembayaran { get; set; }
        public string NamaBuyer { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string JenisProduk { get; set; }
        public string NamaContactPerson { get; set; }
        public string NoTelp { get; set; }
        public int? LamaHubunganTahun { get; set; }

        public Guid SurveyId { get; set; }
        public Guid? RFPaymentMethodsId { get; set; }
    }
}