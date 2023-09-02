using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMappingTenor;
using NewLMS.UMKM.MediatR.Features.RfMappingTenors.Queries.GetFilterRfMappingTenors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfMappingTenor
{
    public class RfMappingTenorController : BaseController
    {
        /// <summary>
        /// GetFilter RfMappingTenor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfMappingTenorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfMappingTenor(RfMappingTenorsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
