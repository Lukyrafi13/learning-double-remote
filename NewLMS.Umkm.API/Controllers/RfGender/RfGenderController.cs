using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfGender;
using NewLMS.UMKM.MediatR.Features.RfGenders.Queries.GetFilterRfGenders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfGender
{
    public class RfGenderController : BaseController
    {
        /// <summary>
        /// GetFilter RfGender
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfGenderResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfGender(RfGendersGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
