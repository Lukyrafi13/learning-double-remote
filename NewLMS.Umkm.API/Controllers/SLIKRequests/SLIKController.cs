using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.MediatR.Features.SLIKRequests.Queries;
using NewLMS.Umkm.Data.Dto.SLIKs;

namespace NewLMS.Umkm.API.Controllers.SIKPs
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
