using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails;
using MediatR;
using NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationCycleDetails.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationCycleDetails.Commands;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationVerificationCycleDetail
{
    public class LoanApplicationVerificationCycleDetailController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationVerificationCycleDetailResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(GetFilterLoanApplicationVerificationCycleDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get LoanApplicationVerificationCycleDetail By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationVerificationCycleDetailResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLoanApplicationVerificationCycleDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a LoanApplicationVerificationCycleDetail
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(PostLoanApplicationVerificationCycleDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update LoanApplicationVerificationCycleDetail Data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] PutLoanApplicationVerificationCycleDetailCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete LoanApplicationVerificationCycleDetail by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteLoanApplicationVerificationCycleDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
