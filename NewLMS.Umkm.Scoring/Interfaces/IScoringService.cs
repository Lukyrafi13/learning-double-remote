using NewLMS.UMKM.Scoring.Models.TypeA;
using NewLMS.UMKM.Scoring.Models.TypeB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Scoring.Interfaces
{
    public interface IScoringService
    {
        Task<ScoringTypeAResponse> CalculateScoringTypeA(ScoringTypeARequest request);
        Task<ScoringTypeDResponse> CalculateScoringTypeD(ScoringTypeDRequest request);
    }
}
