using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBusinessOwnership;
using NewLMS.Umkm.MediatR.Features.RfBusinessOwnerships.GetFilterRfBusinessOwnerships;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBusinessOwnership
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
