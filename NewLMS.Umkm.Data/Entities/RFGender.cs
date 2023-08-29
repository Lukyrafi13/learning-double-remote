﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data
{
    public class RFGender : BaseEntity
    {
        public Guid Id { get; set; }
        public string GenderCode { get; set; }
        public string GenderDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
        public string GenderCodeSIKP { get; set; }
        public string GenderDescSIKP { get; set; }

    }
}
