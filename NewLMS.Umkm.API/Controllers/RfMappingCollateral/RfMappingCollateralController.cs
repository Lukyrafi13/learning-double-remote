using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappingCollateral;
using NewLMS.Umkm.MediatR.Features.RfMappingCollaterals.Queries.GetFilterRfMappingCollaterals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfMappingCollateral
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
