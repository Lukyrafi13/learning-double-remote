using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfGenders;
using NewLMS.Umkm.MediatR.Features.RfGenders.Queries.GetFilterRfGenders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfGender
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
