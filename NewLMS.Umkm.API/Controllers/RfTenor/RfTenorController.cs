using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfTenor;
using NewLMS.UMKM.MediatR.Features.RfTernors.Queries.GetFilterRfTenors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfTenor
{
    public class RfTenorController : BaseController
    {
        /// <summary>
        /// GetFilter RfTenor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfTenorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfTenor(RfTenorsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
