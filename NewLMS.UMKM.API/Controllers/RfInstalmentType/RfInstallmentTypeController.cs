using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfInstallmentTypes;
using NewLMS.Umkm.MediatR.Features.RfInstallmentTypes.Queries.GetFilterRfInstalmetTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfInstallmentType
{
    public class RfInstallmentTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfInstallmentType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfInstallmentTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfCreditNature(RfInstallmentTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
