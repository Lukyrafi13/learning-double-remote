﻿using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.LoanApplicationVerificationBusiness;
using System;

namespace NewLMS.UMKM.Data.Dto.LoanApplicationSurvey
{
    public class LoanApplicationSurveyUpsertRequest
    {
        public Guid LoanApplicationGuid { get; set; }
        public string Tab { get; set; }
        public LoanApplicationFieldSurveyPostRequest? FieldSurvey { get; set; }
        public LoanApplicationVerificationBusinessPostRequest? LoanApplicationVerificationBusiness { get; set; }
    }
}
