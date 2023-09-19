using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfInstituteCodes;
using NewLMS.Umkm.MediatR.Features.RfInstituteCodes.Queries.GetFilterRfInstituteCodes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfInstituteCode
{
    public class RfInstituteCodeController : BaseController
    {
        /// <summary>
        /// GetFilter RfinstituteCode
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfInstituteCodeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfJob(RfInstituteCodeGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
