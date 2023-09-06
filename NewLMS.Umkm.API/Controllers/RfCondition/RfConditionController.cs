using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCondition;
using NewLMS.UMKM.MediatR.Features.RfConditions.Queries.GetFilterRfConditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfCondition
{
    public class RfConditionController : BaseController
    {
        /// <summary>
        /// GetFilter RfCondition
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfConditionResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfConditionsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
