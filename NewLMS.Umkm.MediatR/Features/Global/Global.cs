using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
// using NewLMS.Umkm.Data.Dto.User;
using NewLMS.Umkm.Data;

namespace NewLMS.Umkm.MediatR.Features
{
    public class Globals
    {

        public class DuplicateLMS
        {
            public Guid LoanApplicationGuid { get; set; }
            public string LoanApplicationId { get; set; }
            public string Stage { get; set; }
            public string BranchId { get; set; }
            public string CIF { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string FullName { get; set; }
            public string NoIdentity { get; set; }
            public string NPWP { get; set; }

        }
    }
}