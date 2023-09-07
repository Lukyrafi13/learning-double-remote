using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBranches;
using NewLMS.UMKM.MediatR.Features.RfBranches.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBranch
{
    public class RfBranchController : BaseController
    {
        /// <summary>
        /// GetFilter RfBranch
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBranchResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessFieldKUR(RfBranchGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
