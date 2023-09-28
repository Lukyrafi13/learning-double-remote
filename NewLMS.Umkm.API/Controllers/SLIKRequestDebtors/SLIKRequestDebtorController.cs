using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Queries;
using NewLMS.Umkm.Data.Dto.SLIKs;
using Microsoft.AspNetCore.Authorization;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands;
using NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Queries;
using System;
using MediatR;

namespace NewLMS.Umkm.API.Controllers.SLIKRequestDebtors
{
    [Authorize]
    public class SLIKRequestDebtorController : BaseController
    {
        /// <summary>
        /// GetFilter SLIK
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SLIKRequestTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilter(GetFilterSLIKRequestQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<SLIKRequestDebtorResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] SLIKRequestDebtorGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(SLIKRequestDebtorPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromForm] SLIKRequestDebtorPutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(SLIKRequestDebtorDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
