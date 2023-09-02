using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfMappingCollateral;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.MediatR.Features.RfMappingCollaterals.Queries.GetFilterRfMappingCollaterals;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfMappingCollateral
{
    public class RfMappingCollateralController : BaseController
    {
        /// <summary>
        /// GetFilter RfMappingCollateral
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfMappingCollateralResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfMappingCollateral(RfMappingCollateralsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
