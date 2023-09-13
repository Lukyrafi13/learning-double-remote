using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfPlacementCountry;
using NewLMS.UMKM.MediatR.Features.RfPlacementCountries.Queries.GetFilterRfPlacementCountries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfPlacementCountry
{
    public class RfPlacementCountryController : BaseController
    {
        /// <summary>
        /// GetFilter RfPlacementCountry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfPlacementCountryResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfPlacementCountry(RfPlacementCountryGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
