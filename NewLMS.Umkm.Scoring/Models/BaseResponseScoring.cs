using System;
using System.Collections.Generic;
using System.Text;

namespace NewLMS.UMKM.Scoring.Models
{
    public class BaseResponseScoring
    {
        public double Tetha { get; set; }
        public double Beta { get; set; }
        public double SummaryScoreParameter { get; set; }
        public string Result { get; set; }
    }
}
