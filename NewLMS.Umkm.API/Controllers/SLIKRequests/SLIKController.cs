using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Queries;
using NewLMS.Umkm.Data.Dto.SLIKs;
using Microsoft.AspNetCore.Authorization;
using NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Commands;
using NewLMS.Umkm.Helper;
using MediatR;
using System;
using NewLMS.Umkm.Data.Dto.SLIKRequestDebtors;
using NewLMS.Umkm.MediatR.Features.SLIKRequestDebtors.Queries;
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Command;

namespace NewLMS.Umkm.API.Controllers.SIKPs
{
    [Authorize]
    public class SLIKController : BaseController
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

        /// <summary>
        /// GetFilter SLIK
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get/AKBL")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SLIKRequestTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterAKBL(GetFilterSLIKAKBLRequestQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get SLIK Request By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type:typeof(ServiceResponse<SLIKRequestResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] SLIKRequestGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create SLIKRequestDebtor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("debtor/create")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSLIKRequestDebtor(SLIKRequestDebtorPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update SLIKRequestDebtor </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("debtor/update")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSLIKRequestDebtor(SLIKRequestDebtorPutCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete SLIKRequestDebtor </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("debtor/{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletetSLIKRequestDebtor([FromRoute] Guid Id)
        {
            var command = new SLIKRequestDebtorDeleteCommand
            {
                Id = Id
            };
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        /// <summary>
        /// Process SLIKRequest </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("process/{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessSLIKRequestDebtor([FromRoute] Guid Id)
        {
            var command = new SLIKRequestDebtorProcessCommand
            {
                Id = Id
            };
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        /// <summary>
        /// Process SLIKRequestAKBL </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("process/AKBL/{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessSLIKRequestAKBL([FromRoute] Guid Id)
        {
            var command = new SLIKRequestDebtorProcessCommand
            {
                Id = Id
            };
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        /// <summary>
        /// Submit SLIKRequests AKBL
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("AKBL/submit-kontigensi")]
        [ProducesResponseType(type: typeof(byte[]), statusCode: StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> AKBLSubmitKontigensi(SubmitSLIKKontigensiRequestCommand command)
        {
            var res = await Mediator.Send(command);
            return File(res, "text/plain", $"SLIK_KONTIGENSI_{DateTime.Now.ToString("dd_MM_yyyy")}.txt");
        }
    }
}
