using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NewLMS.Umkm.API.Controllers;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.MediatR.Features.Appraisals.Queries;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Appraisals.Commands;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Dto.AppraisalProductiveLands;
using NewLMS.Umkm.Data.Dto.LoanApplications;

namespace NewLMS.Umkm.API.Controllers.Appraisal
{

    public class AppraisalController : BaseController
    {
        [HttpGet("surveyor/application-info/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationAppInfoApprSurveyorResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getApprLoanAppInfo([FromRoute] GetAppInfoLoanApplicationCollateralQuery command)
        {
            return Ok(await Mediator.Send(command));
        }


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

        [HttpGet("surveyor/get/land-productive-template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprProductiveLandTemplateResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByApprGuid([FromRoute] GetApprProductiveLandTemplateQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("surveyor/post/land-productive-template")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorProductiveTemplatePost(ApprProductiveLandTemplatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpPut("surveyor/put/land-productive-template/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SurveyorProductiveTemplatePut(ApprProductiveLandTemplatePutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}