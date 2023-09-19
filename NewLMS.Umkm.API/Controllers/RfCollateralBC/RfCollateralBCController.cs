using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCollateralBC;
using NewLMS.Umkm.MediatR.Features.RfCollateralBCs.Queries.GetFilterRfCollateralBCs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfCollateralBC
{
    public class RfCollateralBCController : BaseController
    {
        /// <summary>
        /// GetFilter RfCollateralBC
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfCollateralBCResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCollateralBC(RfCollateralBCsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
