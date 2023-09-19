using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCreditNature;
using NewLMS.Umkm.MediatR.Features.RfCreditNatures.Queries.GetFilterRfCreditNatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfCreditNature
{
    public class RfCreditNatureController : BaseController
    {
        /// <summary>
        /// GetFilter RfCreditNature
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfCreditNatureResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfCreditNaturesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
