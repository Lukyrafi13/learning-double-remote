// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Apps.Queries.GetInbox;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace NewLMS.Umkm.API.Controllers.LoanApplication
{
    [Authorize]
    public class LoanApplicationController : BaseController
    {
        /// <summary>
        /// Get LoanApplication Inbox
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-loanapplication-inbox/{Page}/{Length}")]
        [ProducesResponseType(type: typeof(ServiceResponse<AppInboxResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLoanApplicationInbox([FromRoute] GetAppInboxQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
