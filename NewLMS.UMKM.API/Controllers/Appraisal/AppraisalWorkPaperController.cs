/*using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Komersial.Helper;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprLiquidations;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PutApprLiquidations;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.DeleteApprLiquidations;
using NewLMS.Komersial.Data.Dto.AppraisalWorkPaper;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprMachines;
using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.AppLiquidationGetQuery;
// using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprVehicles;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprBuildings;
using NewLMS.Komersial.MediatR.Features.Appraisals.Commands.PostApprProductiveLands;
// using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.ApprVehicleGetQuery;
using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.ApprMachineMarketGetQuery;
using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.ApprMachineCostGetQuery;
using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.ApprProductiveLandGetQuery;
using NewLMS.Komersial.MediatR.Features.AppraisalWorkPaper.Queries.ApprBuildingGetQuery;

namespace NewLMS.Komersial.API.Controllers.Appraisal
{
	
	public class AppraisalWorkPaperController : BaseController
	{

        /// <summary>
        /// vehicle work paper
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        // [HttpPost("vehicle")]
        // [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> VehiclePost(ApprVehiclePostCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }

        // [HttpGet("vehicle/{ApprVehicleTemplateGuid}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<ApprVehicleWorkPaperResponse>), statusCode: StatusCodes.Status200OK)]

        // public async Task<IActionResult> GetVehicleTemplateGuid([FromRoute] GetApprVehicleQuery command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }

        /// <summary>
        /// building work paper : bangunan, ruko
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("building")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> BuildingPost(ApprBuildingPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("building/{ApprBuildingTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprBuildingWorkPaperResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBuildingByTemplateGuid([FromRoute] GetApprBuildingQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Productive Land
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("productive-land")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> LandPost(ApprProductiveLandPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("productive-land/{ApprProductiveLandTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprProductiveLandWorkPaperResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductiveByTemplateGuid([FromRoute] GetApprProductiveLandQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Machine Market Approach
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("machine-market")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> MachineMarketPost(ApprMachineMarketPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("machine-market/{ApprMachineTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprMachineMarketWorkPaperResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetMarketByTemplateGuid([FromRoute] GetApprMachineMarketQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Machine Cost Approach
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("machine-cost")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> MachinePost(ApprMachineCostPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("machine-cost/{ApprMachineTemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprMachineCostWorkPaperResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> GetCostByTemplateGuid([FromRoute] GetApprMachineCostQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

		/// <summary>
        /// liquidation_type : building; land; vehicle, machine;
        /// </summary>
        /// <param name="LiquidationGuid"></param>
        /// <returns></returns>
        [HttpPost("surveyor/liquidation/{LiquidationGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> LiquidationPost([FromRoute] Guid LiquidationGuid, ApprLiquidationPostCommand command)
        {
            command.LiquidationGuid = LiquidationGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("surveyor/liquidation/{TemplateGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprLiquidationResponse>), statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> getByTemplateGuid([FromRoute] GetApprLiquidationQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        // [HttpPut("surveyor/liquidation/{LiquidationGuid}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<ApprLiquidationResponse>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> LiquidationPut([FromRoute] Guid LiquidationGuid, [FromBody] ApprLiquidationPutCommand command)
        // {
        //     command.LiquidationGuid = LiquidationGuid;
        //     return Ok(await Mediator.Send(command));
        // }

        // [HttpDelete("surveyor/liquidation/{LiquidationGuid}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<ApprLiquidationResponse>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> LiquidationDelete([FromRoute] ApprLiquidationDeleteCommand command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }       

	}
}*/