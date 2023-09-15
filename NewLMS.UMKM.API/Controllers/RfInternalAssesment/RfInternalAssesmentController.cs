using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfInternalAssesments;
using NewLMS.UMKM.Data.Dto.RfJob;
using NewLMS.UMKM.Data.Dto.Users;
using NewLMS.UMKM.MediatR.Features.RfJobs.Queries.GetFilterRfJobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfInternalAssesment
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
        public async Task<IActionResult> GetFilterRfJob(RfJobsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
