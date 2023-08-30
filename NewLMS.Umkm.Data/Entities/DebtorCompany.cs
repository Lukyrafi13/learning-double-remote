﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NewLMS.UMKM.Data
{
    public class DebtorCompany : BaseEntity
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        [ForeignKey(nameof(RfZipCode))]
        public int RfZipCodeId { get; set; }
        public string Neighborhoods { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }


        [MaxLength(16)]
        [ForeignKey(nameof(Debtor))]
        public string DebtorId { get; set; }

        public RfZipCode RfZipCode { get; set; }
        public Debtor Debtor { get; set; }

	}
}