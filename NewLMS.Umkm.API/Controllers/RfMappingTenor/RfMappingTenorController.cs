using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappingTenor;
using NewLMS.Umkm.MediatR.Features.RfMappingTenors.Queries.GetFilterRfMappingTenors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfMappingTenor
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
