using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCondition;
using NewLMS.Umkm.MediatR.Features.RfConditions.Queries.GetFilterRfConditions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfCondition
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
