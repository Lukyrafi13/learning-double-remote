using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.ChekingSIKPs;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.ChekingSKIPs.Commands;
using NewLMS.Umkm.MediatR.Features.ChekingSKIPs.Queries;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.ChekingSIKP
{
    [Authorize]
    public class ChekingSIKPController : BaseController
    {
        /// <summary>
        /// SIKP Cheking Get List
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("get")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetListChekingSIKP(GetFilterCheckingSIKPQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get Cheking SIKP By Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<ChekingSIKPHistoryResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetChekingSIKPById([FromRoute] GetByIdCheckingSIKPQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Check SIKP
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("check")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> CheckSIKP(ChekingSIKPChekCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
