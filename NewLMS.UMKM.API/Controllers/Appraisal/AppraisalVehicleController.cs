using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Data.Dto.AppraisalVehicle;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Appraisals.Commands;
using NewLMS.UMKM.MediatR.Features.Appraisals.Queries;

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
}