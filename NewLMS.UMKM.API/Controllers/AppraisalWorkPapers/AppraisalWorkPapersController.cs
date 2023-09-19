using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.MachineWorkPapers;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.ShopAppartmentWorkPaper;
using NewLMS.Umkm.Data.Dto.AppraisalWorkPapers.VehicleWorkPaper;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.AppraisalWorkPapers.Commands;
using NewLMS.Umkm.MediatR.Features.AppraisalWorkPapers.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.AppraisalWorkPapers
{
    public class AppraisalWorkPapersController : BaseController
    {
        [HttpGet("get-land-building/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperLandBuildingHeaderResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprLandBuildingQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-land-building/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromRoute] Guid AppraisalGuid, [FromBody] ApprLandBuildingPostCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-machine/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperMachineResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachine([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprWorkPaperMachineQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-machine/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostMachine([FromRoute] Guid AppraisalGuid, [FromBody] ApprMachineSwitchApproachCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-machine-cost/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperMachineCostResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachineCost([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprMachineCostQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-machine-cost/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostMachineCost([FromRoute] Guid AppraisalGuid, [FromBody] ApprMachineCostPostCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }


        [HttpGet("get-machine-market/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperMachineMarketHeaderResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachineMarket([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprMachineMarketQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-machine-market/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostMachineMarket([FromRoute] Guid AppraisalGuid, [FromBody] ApprMachineMarketPostCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-shop-apartment/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperShopApartmentHeaderResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetShopApartment([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprShopApartmentQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-shop-apartment/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostShopApartment([FromRoute] Guid AppraisalGuid, [FromBody] PostApprShopApartmentCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-vehicle/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ApprWorkPaperVehicleHeaderResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicle([FromRoute] Guid AppraisalGuid)
        {
            return Ok(await Mediator.Send(new GetApprVehicleQuery()
            {
                AppraisalGuid = AppraisalGuid
            }));
        }

        [HttpPost("post-vehicle/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> PostVehicle([FromRoute] Guid AppraisalGuid, [FromBody] PostApprVehicleCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("put-liquidation/{LiquidationGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLiquidation([FromRoute] Guid LiquidationGuid, [FromBody] ApprLiquidationPostCommand command)
        {
            command.LiquidationGuid = LiquidationGuid;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("get-liquidation-option/{ItemId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<List<SimpleResponseWithScore<string>>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLiquidationOption([FromRoute] string ItemId)
        {
            return Ok(await Mediator.Send(new GetMLiquidationOptionQuery()
            {
                ItemId = ItemId
            }));
        }

        [HttpPost("calculate-liquidation/{AppraisalGuid}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateLiquidation([FromRoute] Guid AppraisalGuid, [FromBody] LiquidationCalculateCommand command)
        {
            command.AppraisalGuid = AppraisalGuid;
            return Ok(await Mediator.Send(command));
        }

        // [HttpGet("generate-liquidation-data")]
        // [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> GenerateLiquidationData()
        // {
        //     return Ok(await Mediator.Send(new GenerateMLiquidationOptionQuery()));
        // }
    }
}
