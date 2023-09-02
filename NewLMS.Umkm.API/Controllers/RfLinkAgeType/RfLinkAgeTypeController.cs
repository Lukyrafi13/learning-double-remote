using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfLinkAgeType;
using NewLMS.UMKM.MediatR.Features.RfLinkAgeTypes.Queries.GetFilterRfLinkAgeTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfLinkAgeType
{
    public class RfLinkAgeTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfLinkAgetype
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfLinkAgeTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfLinkAgeType(RfLinkAgeTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
