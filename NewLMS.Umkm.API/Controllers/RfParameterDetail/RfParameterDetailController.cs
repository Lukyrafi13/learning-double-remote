using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.DeleteRfParameterDetails;
using NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PostRfParameterDetails;
using NewLMS.Umkm.MediatR.Features.RfParameterDetails.Commands.PutRfParameterDetails;
using NewLMS.Umkm.MediatR.Features.RfParameterDetails.Queries.GetByIdRfParameterDetails;
using NewLMS.Umkm.MediatR.Features.RfParameterDetails.Queries.GetFilterRfParameterDetails;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfParameterDetail
{
    [Authorize]
    //[AllowAnonymous]
    public class RfParameterDetailController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfParameterDetailResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfParameterDetailGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{ParameterDetailId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfParameterDetailResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfParameterDetailsGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RfParameterDetailPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{ParameterDetailId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] RfParameterDetailPutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{ParameterDetailId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(RfParameterDetailDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
