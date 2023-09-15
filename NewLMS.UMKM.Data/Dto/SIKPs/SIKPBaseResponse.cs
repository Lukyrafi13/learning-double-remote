using System;
using NewLMS.UMKM.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data.Dto.SIKPs
{
    public class SIKPBaseResponse
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public SIKPRequestResponse SIKPRequest { get; set; }
        public SIKPResponseResponse SIKPResponse { get; set; }
    }

    public class SIKPTableResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string DataSource { get; set; }
    }
}

