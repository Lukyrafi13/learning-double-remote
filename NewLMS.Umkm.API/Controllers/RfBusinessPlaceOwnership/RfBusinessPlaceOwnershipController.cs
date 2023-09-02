using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessPlaceOwnership;
using NewLMS.UMKM.MediatR.Features.RfBusinessPlaceOwnerships.Queries.GetFilterRfBusinessPlaceOwnerships;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBusinessPlaceOwnership
{
    public class RfBusinessPlaceOwnershipController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessPlaceOwnership
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessPlaceOwnershipResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessPlaceOwnersip(RfBusinessPlaceOwnershipsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
