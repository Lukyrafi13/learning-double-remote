using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MediatR;
using NewLMS.UMKM.MediatR.Features.LoanApplicationFieldSurveyDetails.Queries;
using NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.UMKM.MediatR.Features.LoanApplicationFieldSurveyDetails.Commands;

namespace NewLMS.UMKM.API.Controllers.LoanApplicationFieldSurveyDetail
{
    public class LoanApplicationFieldSurveyDetailController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationFieldSurveyDetailsResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(GetFilterLoanApplicationFieldSurveyDetailsQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get LoanApplicationFieldSurveyDetail By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLoanApplicationFieldSurveyDetailsQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Create a LoanApplicationFieldSurveyDetail
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(PostLoanApplicationFieldSurveyDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update LoanApplicationFieldSurveyDetail Data
        /// </summary>
        /// <param name="command"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromBody] PutLoanApplicationFieldSurveyDetailsCommand command)
        {
            command.Id = Id;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete LoanApplicationFieldSurveyDetail by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteLoanApplicationFieldSurveyDetailsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
