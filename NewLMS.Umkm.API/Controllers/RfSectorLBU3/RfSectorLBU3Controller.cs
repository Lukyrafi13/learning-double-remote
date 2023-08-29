using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSectorLBU3s;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RFSectorLBU3
{
    // [Authorize]
    //[AllowAnonymous]
    public class RFSectorLbuThreeController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RFSectorLBU3Response>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RFSectorLBU3GetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get RFSectorLBU2 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RFSectorLBU3Response>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RFSectorLBU3sGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Post RFSectorLBU2
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RFSectorLBU3PostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update RFSectorLBU3 By Code
        /// </summary>
        /// <param name="code"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] string code, [FromBody] RFSectorLBU3PutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete RFSectorLBU3 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] RFSectorLBU3DeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
