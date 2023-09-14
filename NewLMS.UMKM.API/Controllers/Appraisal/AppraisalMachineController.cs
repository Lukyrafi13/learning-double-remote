/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using System.Collections.Generic;
using NewLMS.Komersial.Common.GenericRespository;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprMachineTemplates;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppMachineTemplateGetQuery;
using NewLMS.Komersial.Data.Dto.AppraisalMachine;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprMachineTemplates;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	
	public class AppraisalMachineController : BaseController
	{
		/// <summary>
        /// Appraisal surveyor : Machine
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorMachinePost(ApprMachineTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorMachinePut(ApprMachineTemplatePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprMachineTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprMachineTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        
	}
}*/