using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfSubProducts;
using NewLMS.Umkm.MediatR.Features.RfSubProducts.Queries.GetFilterRfSubProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfSubProduct
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
