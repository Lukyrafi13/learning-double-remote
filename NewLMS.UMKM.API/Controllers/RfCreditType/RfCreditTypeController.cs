using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCreditType;
using NewLMS.Umkm.MediatR.Features.RfCreditTypes.Queries.GetFilterRfCreditTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfCreditType
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
