/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Data.Dto.Appraisals;
using NewLMS.Komersial.Data.Dto.AppraisalRefs;
using NewLMS.Komersial.Helper;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppBuildingTemplateGetQuery;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
    public class ApprRefController : BaseController
    {
        
        [HttpGet("property-categories/{LoanApplicatioGuid}")]
        
        public List<PropertyCategoryResponse> getByApprGuid()
        {
            return new List<PropertyCategoryResponse> {
                new PropertyCategoryResponse {PropertyCategoryId = 10, PropertyCategoryName = "Sederhana"},
                new PropertyCategoryResponse {PropertyCategoryId = 20, PropertyCategoryName = "Non-Sederhana"},
            };
        }

        
    }
}
*/