using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessType;
using NewLMS.UMKM.MediatR.Features.RfBusinessTypes.Queries.GetFilterRfBusinessTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBusinessType
{
    public class RfBusinessTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessType(RfBusinessTypeGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
