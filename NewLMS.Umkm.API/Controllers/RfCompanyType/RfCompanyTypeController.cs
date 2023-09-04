using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries.GetFilterRfCompanyTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfCompanyType
{
    public class RfCompanyTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfCompanyType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfCompanyTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfCompanyTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
