using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBanks;
using NewLMS.Umkm.MediatR.Features.RfBanks.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBanks
{
    public class RfBankController : BaseController
    {
        /// <summary>
        /// GetFilter RfBanks
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBankResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessFieldKUR(RfBankGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
