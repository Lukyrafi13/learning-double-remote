using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfInternalAssesments;
using NewLMS.Umkm.MediatR.Features.RfInternalAssesments.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfInternalAssesment
{
    public class RfInternalAssesmentController : BaseController
    {
        /// <summary>
        /// GetFilter RfInternalAssesment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfInternalAssesmentsResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfJob(RfInternalAssesmentsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
