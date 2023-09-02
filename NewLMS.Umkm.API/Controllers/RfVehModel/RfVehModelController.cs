using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehModel;
using NewLMS.UMKM.MediatR.Features.RfVehModels.Queries.GetFilterRfVehModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfVehModel
{
    public class RfVehModelController : BaseController
    {
        /// <summary>
        /// GetFilter RfVehModel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfVehModelResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfVehModel(RfVehModelsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
