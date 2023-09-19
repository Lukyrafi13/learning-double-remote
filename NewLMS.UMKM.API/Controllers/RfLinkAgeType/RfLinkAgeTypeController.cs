using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfLinkAgeType;
using NewLMS.Umkm.MediatR.Features.RfLinkAgeTypes.Queries.GetFilterRfLinkAgeTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfLinkAgeType
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
