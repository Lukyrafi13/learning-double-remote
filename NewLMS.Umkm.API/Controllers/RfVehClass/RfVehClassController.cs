using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehClass;
using NewLMS.UMKM.MediatR.Features.RfVehClasses.Queries.GetFilterRfVehClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfVehClass
{
    public class RfVehClassController : BaseController
    {
        /// <summary>
        /// GetFilter RfVehClass
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfVehClassResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfVehClass(RfVehClassesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
