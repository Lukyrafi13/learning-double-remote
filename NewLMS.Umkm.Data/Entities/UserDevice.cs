﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.Umkm.Data.Entities
{
    public class UserDevice : BaseEntity
    {
        [Key]
        public Guid UserDeviceId { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string DeviceId { get; set; }
        [Precision(8,6)]
        public decimal Latitude { get; set; }
        [Precision(9, 6)]
        public decimal Langitude { get; set; }
        public virtual User User { get; set; }
    }
}
