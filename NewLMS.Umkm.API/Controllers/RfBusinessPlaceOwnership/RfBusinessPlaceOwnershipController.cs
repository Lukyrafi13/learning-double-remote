using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBusinessPlaceOwnership;
using NewLMS.Umkm.MediatR.Features.RfBusinessPlaceOwnerships.Queries.GetFilterRfBusinessPlaceOwnerships;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBusinessPlaceOwnership
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
