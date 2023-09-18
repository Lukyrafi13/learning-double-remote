using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.MediatR.Features.SLIKRequests.Queries;
using NewLMS.UMKM.Data.Dto.SLIKs;

namespace NewLMS.UMKM.API.Controllers.SIKPs
{
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
    }
}
