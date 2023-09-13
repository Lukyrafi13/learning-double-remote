using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMarital;
using NewLMS.UMKM.MediatR.Features.RfMaritals.Queries.GetFilterRfMaritals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfMarital
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
