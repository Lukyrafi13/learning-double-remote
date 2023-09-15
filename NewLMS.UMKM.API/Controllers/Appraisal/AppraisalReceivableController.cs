/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using System.Collections.Generic;
using NewLMS.Komersial.Common.GenericRespository;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprReceivableVerifications;
using NewLMS.Komersial.Data.Dto.AppraisalReceivable;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppReceivableVerificationGetQuery;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprReceivableVerifications;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	
	public class AppraisalReceivableController : BaseController
	{
		/// <summary>
        /// Appraisal surveyor : Receivable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/verification")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorReceivablePost(ApprReceivableVerificationPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/verification/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorReceivablePut(ApprReceivableVerificationPutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/verification/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprReceivableVerificationResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprReceivableVerificationQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        
	}
}*/