using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfBusinessFieldKUR;
using NewLMS.UMKM.MediatR.Features.RfBusinessFieldKURs.Queries.GetFilterRfBusinessFieldKURs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfBusinessFieldKUR
{
    public class RfBusinessFieldKURController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessFieldKUR
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessFieldKURResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessFieldKUR(RfBusinessFieldKURsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
