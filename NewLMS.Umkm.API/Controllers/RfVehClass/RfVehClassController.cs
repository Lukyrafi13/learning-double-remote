using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfVehClass;
using NewLMS.Umkm.MediatR.Features.RfVehClasses.Queries.GetFilterRfVehClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfVehClass
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
