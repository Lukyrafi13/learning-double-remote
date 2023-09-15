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
}

