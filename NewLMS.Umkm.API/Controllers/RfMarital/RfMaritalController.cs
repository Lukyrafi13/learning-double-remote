using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMarital;
using NewLMS.Umkm.MediatR.Features.RfMaritals.Queries.GetFilterRfMaritals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfMarital
{
    public class RfMaritalController : BaseController
    {
        /// <summary>
        /// GetFilter RfMarital
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfMaritalResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfMarital(RfMaritalsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
