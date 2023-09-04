using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Commands;
using NewLMS.Umkm.MediatR.Features.RFSectorLBU1s.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSectorLBU1s;
using NewLMS.UMKM.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfSectorLBU1
{
    public class RfSectorLBU1Controller : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfSectorLBU1Response>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RFSectorLBU1GetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get RFSectorLBU1 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<RfSectorLBU1Response>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] RFSectorLBU1GetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(RFSectorLBU1PostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update RFSectorLBU1 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] RFSectorLBU1PutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete RFSectorLBU1 By Code
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Code}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] RFSectorLBU1DeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
