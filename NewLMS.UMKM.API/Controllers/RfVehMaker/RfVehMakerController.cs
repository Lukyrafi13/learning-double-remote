using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMappingTenor;
using NewLMS.UMKM.Data.Dto.RfVehMaker;
using NewLMS.UMKM.MediatR.Features.RfMappingTenors.Queries.GetFilterRfMappingTenors;
using NewLMS.UMKM.MediatR.Features.RfVehMakers.Queries.GetFilterRfVehMakers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfVehMaker
{
    public class RfVehMakerController : BaseController
    {
        /// <summary>
        /// GetFilter RfVehMaker
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfVehMakerResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfVehMaker(RfVehMakersGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
