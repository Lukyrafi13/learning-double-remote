using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Domain.FUSE.Models
{
    public class SBDKModel
    {
        public Guid SBDKGuid { get; set; }
        public DateTime? Period { get; set; }
        public double? HPDKKorporasi { get; set; }
        public double? HPDKRitel { get; set; }
        public double? HPDKMikro { get; set; }
        public double? HPDKKPR { get; set; }
        public double? HPDKNonKPR { get; set; }
        public double? OverHeadKorporasi { get; set; }
        public double? OverHeadRitel { get; set; }
        public double? OverHeadMikro { get; set; }
        public double? OverHeadKPR { get; set; }
        public double? OverHeadNonKPR { get; set; }
        public double? MarjinKorporasi { get; set; }
        public double? MarjinRitel { get; set; }
        public double? MarjinMikro { get; set; }
        public double? MarjinKPR { get; set; }
        public double? MarjinNonKPR { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}