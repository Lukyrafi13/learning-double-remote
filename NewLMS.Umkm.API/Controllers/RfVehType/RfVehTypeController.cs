using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfVehType;
using NewLMS.Umkm.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfVehType
{
    public class RfVehTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfVehType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfVehTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfVehType(RfVehTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
