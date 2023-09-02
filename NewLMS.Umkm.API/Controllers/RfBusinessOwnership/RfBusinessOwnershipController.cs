using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessOwnership;
using NewLMS.UMKM.MediatR.Features.RfBusinessOwnerships.GetFilterRfBusinessOwnerships;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBusinessOwnership
{
    public class RfBusinessOwnershipController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessOwnership
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessOwnershipResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessOwnerships(RfBusinessOwnershipsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
