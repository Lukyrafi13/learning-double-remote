using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.API.Controllers;
using NewLMS.Umkm.Data.Dto.AppraisalReceivable;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Appraisals.Commands;
using NewLMS.Umkm.MediatR.Features.Appraisals.Queries;

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
}