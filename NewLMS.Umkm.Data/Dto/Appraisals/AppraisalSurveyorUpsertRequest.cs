﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLMS.Umkm.Data.Dto.Appraisals
{
    public class AppraisalSurveyorUpsertRequest
    {
        public Guid LoanApplicationCollateralId { get; set; }
        public string CollateralCode { get; set; }
    }
}
