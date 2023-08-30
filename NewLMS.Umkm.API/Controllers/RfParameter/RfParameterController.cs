using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.Umkm.MediatR.Features.RfParameters.Commands.DeleteRfParameters;
using NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PostRfParameters;
using NewLMS.Umkm.MediatR.Features.RfParameters.Commands.PutRfParameters;
using NewLMS.Umkm.MediatR.Features.RfParameters.Queries.GetByIdParameters;
using NewLMS.Umkm.MediatR.Features.RfParameters.Queries.GetFilterParameters;
using NewLMS.UMKM.API.Controllers;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NewLMS.Umkm.API.Controllers.RfParameter
{
    [Authorize]
    //[AllowAnonymous]
    public class RfParameterController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfParameterResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RfParameterGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{ParameterId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfParameterResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RfParametersGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RfParameterPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{ParameterId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] RfParameterPutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{ParameterId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(RfParameterDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
