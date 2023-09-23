﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMappings;
using NewLMS.Umkm.MediatR.Features.RfMappings.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfMapping
{
    public class RfMappingController : BaseController
    {
        /// <summary>
        /// GetFilter MappingSubProduct
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("subproduct/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfMappingSubProductResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterMappingSubProduct(RfMappingsSubProductQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
