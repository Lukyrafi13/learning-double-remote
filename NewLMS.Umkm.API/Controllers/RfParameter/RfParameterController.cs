using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfParameter;
using NewLMS.UMKM.MediatR.Features.RfParameters.Queries.GetFilterRfparameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfParameter
{
    public class RfParameterController : BaseController
    {
        /// <summary>
        /// GetFilter RfParameter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfParameterResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfParameter(RfParametersGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
