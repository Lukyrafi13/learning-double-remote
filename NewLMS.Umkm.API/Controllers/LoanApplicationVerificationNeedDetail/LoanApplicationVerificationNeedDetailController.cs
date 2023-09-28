using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationVerificationNeedDetail
{
    public class LoanApplicationVerificationNeedDetailController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationVerificationNeedDetailsResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(LoanApplicationVerificationNeedDetailsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get LoanApplicationVerificationNeedDetail By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] LoanApplicationVerificationNeedDetailsGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a LoanApplicationVerificationNeedDetail
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(LoanApplicationVerificationNeedDetailsPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update LoanApplicationVerificationNeedDetail Data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] LoanApplicationVerificationNeedDetailsPutCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete LoanApplicationVerificationNeedDetail by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(LoanApplicationVerificationNeedDetailsDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
