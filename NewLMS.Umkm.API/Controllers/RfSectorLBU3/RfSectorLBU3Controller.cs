using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using NewLMS.UMKM.Helper;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Commands;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace NewLMS.UMKM.API.Controllers.RfSectorLBU3
{
    public class RfSectorLBU3Controller : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfSectorLBU3Response>>), statusCode: StatusCodes.Status200OK)]
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
        [ProducesResponseType(type: typeof(ServiceResponse<RfSectorLBU3Response>), statusCode: StatusCodes.Status200OK)]
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
