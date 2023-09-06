using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfInstalmentType;
using NewLMS.UMKM.MediatR.Features.RfInstalmentTypes.Queries.GetFilterRfInstalmetTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfInstalmentType
{
    public class RfInstalmentTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfInstalmentType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfInstalmentTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfInstalmentTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
