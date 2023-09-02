using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfLinkAge;
using NewLMS.UMKM.MediatR.Features.RfLinkAges.Queries.GetFilterRfLinkAges;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfLinkAge
{
    public class RfLinkAgeController : BaseController
    {
        /// <summary>
        /// GetFilter RfLinkAge
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfLinkAgeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfLinkAge(RfLinkAgesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
