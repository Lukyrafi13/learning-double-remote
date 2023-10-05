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
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Command;
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Commands;

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
        /// GetFilter SLIK AKBL
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get/AKBL")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SLIKRequestTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterAKBL(GetFilterSLIKRequestAKBLQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// GetFilter SLIK Admin
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get/Admin")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SLIKRequestTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterAdmin(GetFilterSLIKAdminQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get SLIK Request By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<SLIKRequestResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] SLIKRequestGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Process SLIKRequest </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("process/{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessSLIKRequest([FromRoute] Guid Id)
        {
            var command = new SLIKRequestProcessCommand
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
            var command = new SLIKRequestAKBLProcessCommand
            {
                Id = Id
            };
            var res = await Mediator.Send(command);

            return Ok(res);
        }

        /// <summary>
        /// Process SLIK Admin </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("process/admin/{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessSLIKAkmin([FromRoute] Guid Id, [FromBody] SLIKAdminProcessRequest request)
        {
            var command = new SLIKRequestAKBLProcessCommand
            {
                Id = Id,
                TotalCreditCard = request.TotalCreditCard,
                TotalLimitSlik = request.TotalLimitSlik,
                TotalOtherUses = request.TotalOtherUses,
                TotalWorkingCapital = request.TotalWorkingCapital
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
