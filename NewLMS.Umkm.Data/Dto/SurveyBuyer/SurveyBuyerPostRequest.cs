using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NewLMS.UMKM.Data.Dto.SurveyBuyers
{
    public class SurveyBuyerPostRequestDto
    {
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
