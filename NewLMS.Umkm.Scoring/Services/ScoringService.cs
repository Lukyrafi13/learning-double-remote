using NewLMS.Umkm.Scoring.Interfaces;
using NewLMS.Umkm.Scoring.Models.TypeA;
using NewLMS.Umkm.Scoring.Models.TypeB;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Scoring.Services
{
    public class ScoringService : IScoringService
    {
        public ScoringService()
        {
        }

        public async Task<ScoringTypeAResponse> CalculateScoringTypeA(ScoringTypeARequest request)
        {
            double beta = -0.218128;
            var resCalculate = await CalucateTetha(beta, request.ScoreParameter.Sum());
            return new ScoringTypeAResponse
            {
                Beta = beta,
                SummaryScoreParameter = request.ScoreParameter.Sum(),
                Tetha = resCalculate.Tetha,
                Result = resCalculate.Result
            };
        }

        public async Task<ScoringTypeDResponse> CalculateScoringTypeD(ScoringTypeDRequest request)
        {
            double beta = 2.45175;
            var resCalculate = await CalucateTetha(beta, request.ScoreParameter.Sum());
            return new ScoringTypeDResponse
            {
                Beta = beta,
                SummaryScoreParameter = request.ScoreParameter.Sum(),
                Tetha = resCalculate.Tetha,
                Result = resCalculate.Result
            };
        }

        private Task<CalculateTethaResponse> CalucateTetha(double beta, double scoreParameter)
        {
            string resultScoring = "";
            double betaScoreParamter = beta + scoreParameter;
            var res = (Math.Exp(betaScoreParamter)) / (1 + Math.Exp(betaScoreParamter));
            if (res > 0.75)
                resultScoring = "MENARIK";
            else if (res > 0.5 && res < 0.75)
                resultScoring = "NETRAL";
            else
                resultScoring = "SELEKTIF";
            return Task.FromResult(new CalculateTethaResponse
            {
                Result = resultScoring,
                Tetha = res
            });
        }
    }
    public class CalculateTethaResponse
    {
        public double Tetha { get; set; }
        public string Result { get; set; }
    }
}
