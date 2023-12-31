﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Entities
{
    public class RfProduct : BaseEntity
    {
        [Key]
        [Required]
        public string ProductId { get; set; }
        public string ProductDesc { get; set; }
        public string ProductType { get; set; }
        public int DefTenor { get; set; }
        public int MaxTenor { get; set; }
        public string DefIntType { get; set; }
        public double DefInterest { get; set; }
        public double MinInterest { get; set; }
        public double MaxInterest { get; set; }
        public double DefProvPCTFee { get; set; }
        public double DefAdminFee { get; set; }
        public double MaxLimit { get; set; }
        public double LimitAppR { get; set; }
        public double MinLimit { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}
