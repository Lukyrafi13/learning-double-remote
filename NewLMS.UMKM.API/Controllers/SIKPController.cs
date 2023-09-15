using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.MediatR.Features.RfVehTypes.Queries.GetFilterRfVehTypes;
using NewLMS.UMKM.MediatR.Features.SIKPs.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.SIKPs
{
    public class SIKPController : BaseController
    {
        /// <summary>
        /// GetById SIKP
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SIKPBaseResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var query = new GetSIKPByIdQuery()
            {
                Id = Id
            };
            return Ok(await Mediator.Send(query));
        }

        /// <summary>
        /// GetFilter SIKP
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<SIKPTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfVehType(SIKPGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
