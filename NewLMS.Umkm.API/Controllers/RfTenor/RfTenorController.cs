using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfTenor;
using NewLMS.Umkm.MediatR.Features.RfTernors.Queries.GetFilterRfTenors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfTenor
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
