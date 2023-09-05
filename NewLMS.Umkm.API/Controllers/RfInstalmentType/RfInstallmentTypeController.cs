using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfInstallmentTypes;
using NewLMS.UMKM.MediatR.Features.RfInstallmentTypes.Queries.GetFilterRfInstalmetTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfInstallmentType
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
