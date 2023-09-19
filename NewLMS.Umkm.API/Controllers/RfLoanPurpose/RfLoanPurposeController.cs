using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfLoanPurpose;
using NewLMS.Umkm.MediatR.Features.RfLoanPurposes.Queries.GetFilterRfLoanPurposes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfLoanPurpose
{
    public class RfLoanPurposeController : BaseController
    {
        /// <summary>
        /// GetFilter RfLoanPurpose
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfLoanPurposeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfLoanPurpose(RfLoanPurposesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
