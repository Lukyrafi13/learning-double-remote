using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappingTenor;
using NewLMS.Umkm.Data.Dto.RfTransportationType;
using NewLMS.Umkm.MediatR.Features.RfMappingTenors.Queries.GetFilterRfMappingTenors;
using NewLMS.Umkm.MediatR.Features.RfTransportationTypes.Queries.GetFilterRfTransportationTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfTransportationType
{
    public class RfTransportationTypeController : BaseController
    {
        /// <summary>
        /// GetFilter RfTransportaionType
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfTransportationTypeResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfTransportationType(RfTransportationTypesGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
