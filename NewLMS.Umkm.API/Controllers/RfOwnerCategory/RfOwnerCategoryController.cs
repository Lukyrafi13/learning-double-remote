using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfOwnerCategory;
using NewLMS.UMKM.MediatR.Features.RfOwnerCategories.Queries.GetFilterRfOwnerCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfOwnerCategory
{
    public class RfOwnerCategoryController : BaseController
    {
        /// <summary>
        /// GetFilter RfOwnerCategory
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfOwnerCategoryResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCategory(RfOwnerCategoriesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
