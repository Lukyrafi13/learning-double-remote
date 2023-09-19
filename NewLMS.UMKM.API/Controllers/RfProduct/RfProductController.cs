using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfProducts;
using NewLMS.Umkm.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfProduct
{
    public class RfProductController : BaseController
    {
        /// <summary>
        /// GetFilter RfProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfProductResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfProduct(RfProductsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
