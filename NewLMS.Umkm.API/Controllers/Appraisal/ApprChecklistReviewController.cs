using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.ApprChecklistReviews;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.ApprChecklistReviews.Commands;
using NewLMS.Umkm.MediatR.Features.ApprChecklistReviews.Queries;

namespace NewLMS.Umkm.API.Controllers.Appraisal
{

    public class ApprChecklistReviewController : BaseController
    {
        /// <summary>
        /// Appraisal checklist review
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>        
        [HttpPost("")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ChecklistReviewPost(ApprChecklistReviewPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("appraisal/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprChecklistReviewResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetByGuid([FromRoute] GetByAppraisalQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{ApprChecklistReviewGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprChecklistReviewResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid ApprChecklistReviewGuid, [FromBody] ApprChecklistReviewPutCommand command)
        {
            command.ApprChecklistReviewGuid = ApprChecklistReviewGuid;
            return Ok(await Mediator.Send(command));
        }


    }
}