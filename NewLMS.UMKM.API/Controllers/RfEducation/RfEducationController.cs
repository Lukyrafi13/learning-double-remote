using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfEducation;
using NewLMS.Umkm.MediatR.Features.RfEducations.Queries.GetFilterRfEducations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfEducation
{
    public class RfEducationController : BaseController
    {
        /// <summary>
        /// GetFilter RfEducation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfEducationResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfEducation(RfEducationsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
