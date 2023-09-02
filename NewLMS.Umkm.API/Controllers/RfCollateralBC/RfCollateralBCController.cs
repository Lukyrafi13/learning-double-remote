using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCollateralBC;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.MediatR.Features.RfCollateralBCs.Queries.GetFilterRfCollateralBCs;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfCollateralBC
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
