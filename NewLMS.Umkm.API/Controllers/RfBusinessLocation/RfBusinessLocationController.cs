using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessLocation;
using NewLMS.UMKM.MediatR.Features.RfBusinessLocations.Queries.GetFilterRfBusinessLocations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBusinessLocation
{
    public class RfBusinessLocationController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinesslocation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessLocationResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessLocation(RfBusinessLocationsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
