using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFHOMESTA : BaseEntity
    {
        public Guid Id { get; set; }
        public string HMSTA_CODE { get; set; }
        public string HMSTA_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ACTIVE { get; set; }
    }
}