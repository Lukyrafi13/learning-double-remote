using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfScPosition;
using NewLMS.Umkm.MediatR.Features.RfScPositions.Queries.GetFilterRfScPositions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfScPosition
{
    public class RfScPositionController : BaseController
    {
        /// <summary>
        /// GetFilter RfScPosition
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfScPositionResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfScProsition(RfScPositionsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
