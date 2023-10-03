using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Queries.GetFilterLoanApplicationCreditHistories;
using NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Queries.GetByIdLoanApplicationCreditHistories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.LoanApplicationCreditHistory;
using NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PostLoanApplicationCreditHistories;
using NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.PutLoanApplicationCreditHistories;
using NewLMS.Umkm.MediatR.Features.LoanApplicationCreditHistories.Commands.DeleteLoanApplicationCreditHistories;
using NewLMS.Konsumer.MediatR.Features.LoanApplicationCreditHistories.Queries.GetWorstCollectabilityApplicationCreditHistories;

namespace NewLMS.Umkm.API.Controllers.LoanApplicationCreditHistories.LoanApplicationCreditHistory
{
    [Authorize]
    // [AllowAnonymous]
    public class LoanApplicationCreditHistoryController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationCreditHistoryResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(LoanApplicationCreditHistoryGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{CreditHistoryId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationCreditHistoryResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] LoanApplicationCreditHistoriesGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("Post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(LoanApplicationCreditHistoryPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// Update Credit History
        /// </summary>
        /// <param name="command"></param>
        /// <param name="CreditHistoryId"></param>
        /// <returns></returns> 
        [HttpPut("{CreditHistoryId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid CreditHistoryId, [FromBody] LoanApplicationCreditHistoriesPutCommand command)
        {
            command.CreditHistoryId = CreditHistoryId;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Delete Credit History by CreditHistoryId
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{CreditHistoryId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] LoanApplicationCreditHistoriesDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get By Worst Collectability
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("get-by-worst-collectability/{LoanApplicationId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<LoanApplicationCreditHistoryResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] GetWorstCollectabilityQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
