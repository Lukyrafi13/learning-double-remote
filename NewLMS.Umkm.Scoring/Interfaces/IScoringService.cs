using NewLMS.Umkm.Scoring.Models.TypeA;
using NewLMS.Umkm.Scoring.Models.TypeB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Scoring.Interfaces
{
    public interface IScoringService
    {
        Task<ScoringTypeAResponse> CalculateScoringTypeA(ScoringTypeARequest request);
        Task<ScoringTypeDResponse> CalculateScoringTypeD(ScoringTypeDRequest request);
    }
}
