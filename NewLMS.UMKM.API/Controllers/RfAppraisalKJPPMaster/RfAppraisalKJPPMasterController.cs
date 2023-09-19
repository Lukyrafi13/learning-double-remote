using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfAppraisalKJPPMasters;
using NewLMS.Umkm.MediatR.Features.RfAppraisalKJPPMasters.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfAppraisalKJPPMaster
{
    public class RfAppraisalKJPPMasterController : BaseController
    {
        /// <summary>
        /// GetFilter RfKJPPMAster
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfAppraisalKJPPMastersResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessFieldKUR(RfAppraisalKJPPMastersGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
