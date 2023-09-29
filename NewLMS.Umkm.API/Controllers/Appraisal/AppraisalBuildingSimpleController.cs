/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using System.Collections.Generic;
using NewLMS.Komersial.Common.GenericRespository;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprBuildingSimpleTemplates;
using NewLMS.Komersial.Data.Dto.AppraisalReceivable;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprBuildingSimpleTemplates;
using NewLMS.Komersial.Data.Dto.Appraisals;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppBuildingSimpleTemplateGetQuery;
using Microsoft.AspNetCore.Authorization;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	[Authorize]
	public class AppraisalBuildingSimpleController : BaseController
	{
		/// <summary>
        /// Appraisal surveyor : Building Simple
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorPost(ApprBuildingSimpleTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorPut(ApprBuildingSimpleTemplatePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingSimpleTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprBuildingSimpleTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        
	}
}*/