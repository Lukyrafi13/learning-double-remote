using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Data.Dto.RfParameters;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.MediatR.Features.RfParameters.Queries.GetFilterRfparameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfParameter
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
