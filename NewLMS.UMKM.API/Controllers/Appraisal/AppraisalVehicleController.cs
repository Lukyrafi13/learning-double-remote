/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using System.Collections.Generic;
using NewLMS.Komersial.Common.GenericRespository;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprBuildingFloors;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.DeleteApprBuildingFloors;
using NewLMS.Komersial.Data.Dto.Appraisals;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprBuildingFloors;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppBuildingFloorGetQuery;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppBuildingTemplateGetQuery;
using NewLMS.Komersial.Data.Dto.LoanApplicationDto;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprVehicleTemplates;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppVehicleTemplateGetQuery;
using NewLMS.Komersial.Data.Dto.AppraisalVehicle;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprVehicleNotes;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprVehicleNotes;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.DeleteApprVehicleNotes;
using NewLMS.Komersial.MediatR.Features.Appraisals.Queries.AppVehicleNoteGetQuery;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	
	public class AppraisalVehicleController : BaseController
	{
		/// <summary>
        /// Appraisal surveyor : vehicle template
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorVehicleTemplatePost(ApprVehicleTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprVehicleTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprVehicleTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal surveyor : vehicle note
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>        
        [HttpPost("surveyor/vehicle-note")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorVehicleNotePost(ApprVehicleNotePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/vehicle-note/{VehicleTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprVehicleNoteResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetNoteByTemplateGuid([FromRoute] GetApprVehicleNoteQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/vehicle-note/{VehicleNoteGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprVehicleNoteResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> NoteUpdate([FromRoute] Guid VehicleNoteGuid, [FromBody] ApprVehicleNotePutCommand command)
        {
            command.VehicleNoteGuid = VehicleNoteGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("surveyor/vehicle-note/{VehicleNoteGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprVehicleNoteResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> NoteDelete([FromRoute] ApprVehicleNoteDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        

	}
}*/