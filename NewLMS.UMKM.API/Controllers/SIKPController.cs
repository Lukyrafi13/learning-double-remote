using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.SIKPs;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.SIKPs.Queries;
using NewLMS.Umkm.SIKP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.MediatR.Features.SIKPs.SIKP;
using Microsoft.AspNetCore.Authorization;

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
            var query = new GetParameterByCodeQuery()
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
        public async Task<IActionResult> GetFilter(GetParameterByNameQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Check SIKP
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("check")]
        [ProducesResponseType(type: typeof(ServiceResponse<DetailCalonDebiturResponseModel>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckSIKP(CheckSIKPCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
