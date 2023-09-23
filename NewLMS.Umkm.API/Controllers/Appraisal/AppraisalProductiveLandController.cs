/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using System.Collections.Generic;
using NewLMS.Komersial.Common.GenericRespository;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprProductiveLandTemplates;
using NewLMS.Komersial.Data.Dto.AppraisalProductiveLands;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppProductiveLandTemplateGetQuery;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprProductiveLandTemplates;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	
	public class AppraisalProductiveLandController : BaseController
	{
		/// <summary>
        /// Appraisal surveyor : productive land template
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorProductiveTemplatePost(ApprProductiveLandTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorProductiveTemplatePut(ApprProductiveLandTemplatePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprProductiveLandTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprProductiveLandTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        
	}
}*/