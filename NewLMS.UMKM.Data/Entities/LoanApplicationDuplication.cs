﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class LoanApplicationDuplication : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string TypeId { get; set; }
        [MaxLength(20)]
        public string SearchType { get; set; }
        [MaxLength(20)]
        public string SearchId { get; set; }
        [MaxLength(100)]
        public string SearchDesc { get; set; }
        [MaxLength(5)]
        public string ResultType { get; set; }

        [ForeignKey(nameof(LoanApplication))]
        public Guid LoanApplicationGuid { get; set; }

        public string Stage { get; set; }
        public string Fullname { get; set; }
        public string NoIdentity { get; set; }
        public string CIF { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Branch { get; set; }
        public string Npwp { get; set; }
        public string CustType { get; set; }
        public decimal Outstanding { get; set; }
        public string LoanType { get; set; }
        public decimal Limit { get; set; }
        public string BankName { get; set; }
        public DateTime? Expired { get; set; }
        public string ReferenceNo { get; set; }
        public virtual LoanApplication LoanApplication { get; set; }
    }
}
