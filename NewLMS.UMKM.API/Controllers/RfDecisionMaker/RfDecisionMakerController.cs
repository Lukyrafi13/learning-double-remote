using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfDecisionMakers;
using NewLMS.UMKM.MediatR.Features.RfDecisionMakers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfDecisionMaker
{
    public class RfDecisionMakerController : BaseController
    {
        /// <summary>
        /// GetFilter RfDecisionMaker
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfDecisionMakerResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfDecisionMakerGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
