using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfCompanyTypes;
using NewLMS.Umkm.MediatR.Features.RfCompanyTypes.Queries.GetFilterRfCompanyTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfCompanyType
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
