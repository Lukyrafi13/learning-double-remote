using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.LoanApplicationStageProcess.Commands;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.LoanApplicationStageProcess
{
    public class LoanApplicationStageProcessController : BaseController
    {
        /// <summary>
        /// Process Appraisal Asignment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appr-asignment/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(LoanAppStageProcessApprAsignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
