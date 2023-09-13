﻿
using System.ComponentModel.DataAnnotations;

namespace NewLMS.UMKM.Data.Entities
{
    public class RfDecisionMaker : BaseEntity
    {
        [Key]
        [Required]
        public string DecisionMakerCode { get; set; }
        public string DecisionMakerDescription { get; set; }
    }
}
