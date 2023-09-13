using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfSubProducts;
using NewLMS.UMKM.MediatR.Features.RfSubProducts.Queries.GetFilterRfSubProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfSubProduct
{
    public class RfSubProductController : BaseController
    {
        /// <summary>
        /// GetFilter RfSubProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfSubProductResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfSubProduct(RfSubProductsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
