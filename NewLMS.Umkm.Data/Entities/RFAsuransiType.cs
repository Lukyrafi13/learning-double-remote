using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewLMS.UMKM.Data
{
    public class RFAsuransiType : BaseEntity
    {
        public Guid Id { get; set; }
        public string AsuransiCode { get; set; }
        public string AsuransiDesc { get; set; }
        public string CoreCode { get; set; }
        public bool Active { get; set; }
    }
}