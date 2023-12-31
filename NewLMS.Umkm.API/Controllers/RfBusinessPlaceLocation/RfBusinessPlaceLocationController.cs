﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto;
using NewLMS.Umkm.MediatR.Features.RfBusinessPlaceLocations.Queries.GetFilterRfBusinessPlaceLocations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfBusinessPlaceLocation
{
    public class RfBusinessPlaceLocationController : BaseController
    {
        /// <summary>
        /// GetFilter RfBusinessPlaceLocation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfBusinessPlaceLocationResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfBusinessPlaceLocation(RfBusinessPlaceLocationsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
