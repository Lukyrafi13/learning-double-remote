using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBusinessType;
using NewLMS.Umkm.MediatR.Features.RfBusinessTypes.Queries.GetFilterRfBusinessTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBusinessType
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
