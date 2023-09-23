using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfDecisionMakers;
using NewLMS.Umkm.MediatR.Features.RfDecisionMakers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfDecisionMaker
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
