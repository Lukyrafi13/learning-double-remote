using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.MediatR.Features.Appraisals.Queries;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Appraisals.Commands;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;

namespace NewLMS.UMKM.API.Controllers.Appraisal
{

    public class AppraisalController : BaseController
    {
        /// <summary>
        /// Appraisal surveyor : building template
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/building-template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorBuildingTemplatePost(ApprBuildingTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/building-template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprBuildingTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal surveyor : building floor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>        
        [HttpPost("surveyor/building-template-floor")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorBuildingFloorPost(ApprBuildingFloorPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/building-template-floor/{BuildingTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingFloorResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByTemplateGuid([FromRoute] GetApprBuildingFloorQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/building-template-floor/{BuildingFloorGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingFloorEntityResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid BuildingFloorGuid, [FromBody] ApprBuildingFloorPutCommand command)
        {
            command.BuildingFloorGuid = BuildingFloorGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("surveyor/building-template-floor/{BuildingFloorGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingFloorEntityResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> BuildingFloorDelete([FromRoute] ApprBuildingFloorDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal surveyor : building floor detail
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("surveyor/building-template-floor-detail/{BuildingFloorGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<List<ApprBuildingFloorDetailResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> getByDetailTemplateGuid([FromRoute] GetApprBuildingFloorDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("surveyor/building-template-floor-detail")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorBuildingFloorDetailPost(ApprBuildingFloorDetailPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("surveyor/building-template-floor-detail/{BuildingFloorDetailGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingFloorDetailResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorBuildingFloorDetailPut([FromRoute] Guid BuildingFloorDetailGuid, [FromBody] ApprBuildingFloorDetailPutCommand command)
        {
            command.BuildingFloorDetailGuid = BuildingFloorDetailGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("surveyor/building-template-floor-detail/{BuildingFloorDetailGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingFloorDetailResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] ApprBuildingFloorDetailDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Appraisal surveyor : land template
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/land-template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorLandTemplatePost(ApprLandTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/land-template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprLandTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getLandByApprGuid([FromRoute] GetApprLandTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}