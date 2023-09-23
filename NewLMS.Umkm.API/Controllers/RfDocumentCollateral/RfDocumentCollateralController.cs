using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfDocumentCollateral;
using NewLMS.Umkm.MediatR.Features.RfDocumentCollaterals.Queries.GetFilterRfDocumentCollaterals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfDocumentCollateral
{
    public class RfDocumentCollateralController : BaseController
    {
        /// <summary>
        /// GetFilter RfDocumentCollateral
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfDocumentCollateralResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfDocumentCollateral(RfDocumentCollateralsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
