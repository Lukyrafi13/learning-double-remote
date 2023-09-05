using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCreditType;
using NewLMS.UMKM.MediatR.Features.RfCreditTypes.Queries.GetFilterRfCreditTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfCreditType
{
    public class RfCreditTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfCreditType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfCreditTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfCreditTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
