using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSectorLBU2s;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Commands;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU2s.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RFSectorLBU2
{
    // [Authorize]
    //[AllowAnonymous]
    public class RFSectorLbuTwoController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RFSectorLBU2Response>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RFSectorLBU2GetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get RFSectorLBU2 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RFSectorLBU2Response>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RFSectorLBU2GetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RFSectorLBU2PostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update RFSectorLBU2 By Code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] string code, [FromBody] RFSectorLBU2PutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete RFSectorLBU2 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] RFSectorLBU2DeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
