using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfJob;
using NewLMS.Umkm.MediatR.Features.RfJobs.Queries.GetFilterRfJobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfJob
{
    public class RfJobController : BaseController
    {
        /// <summary>
        /// GetFilter RfJob
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfJobResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfJob(RfJobsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
