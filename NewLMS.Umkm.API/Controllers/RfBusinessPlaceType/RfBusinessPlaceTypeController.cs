using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBusinessPlaceType;
using NewLMS.Umkm.MediatR.Features.RfBusinessTypePlaces.Queries.GetFilterRfBusinessTypePlaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBusinessPlaceType
{
    public class RfBusinessPlaceTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessPlaceType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessPlaceType(RfBusinessPlaceTypeGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
