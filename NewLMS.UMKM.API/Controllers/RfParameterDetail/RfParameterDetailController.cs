using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.MediatR.Features.RfParameterDetails.Queries.GetFilterRfParameterDetails;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfParameterDetail
{
    public class RfParameterDetailController : BaseController
    {
        /// <summary>
        /// GetFilter RfParameterDetail
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfParameterDetailResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfParameterDetail(RfParameterDetailsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
