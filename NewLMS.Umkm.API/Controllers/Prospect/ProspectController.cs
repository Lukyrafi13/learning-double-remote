using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfTenor;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.RfTernors.Queries.GetFilterRfTenors;
using NewLMS.UMKM.Data.Dto.Prospects;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.MediatR.Features.Prospects.Commands;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using System;

namespace NewLMS.UMKM.API.Controllers.RfTenor
{
    public class ProspectController : BaseController
    {
        public IMediator _mediator { get; set; }
        /// <summary>
        /// Create Prospect
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Guid>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(ProspectPostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Prospect
        /// </summary>
        /// <param name="mediator"></param>
        public ProspectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Prospect By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetProspectById")]
        [Produces("application/json", "application/xml", Type = typeof(ProspectResponse))]
        public async Task<IActionResult> GetProspectById(string Id)
        {
            var getStatusTargetQuery = new ProspectsGetByIdQuery { Id = Id };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get Prospect List
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetProspectList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ProspectResponse>>))]
        public async Task<IActionResult> GetProspectList(ProspectsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Edit Prospect
        /// </summary>
        /// <param name="ProspectPutCommand"></param>
        /// <returns></returns>
        [HttpPut("put", Name = "ProspectPutCommand")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> Put([FromBody] ProspectPutCommand prospectPutCommand)
        {
            var result = await _mediator.Send(prospectPutCommand);

            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete Prospect
        /// </summary>
        /// <param name="ProspectDeleteCommand"></param>
        /// <returns></returns>
        [HttpPut("put", Name = "command")]
        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(ProspectDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }



        // /// <summary>
        // /// Post New Prospect
        // /// </summary>
        // /// <param name="postProspect"></param>
        // /// <returns></returns>
        // [HttpPost("post", Name = "AddProspect")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectResponseDto>))]
        // public async Task<IActionResult> AddProspect(ProspectPostCommand postProspect)
        // {
        //     var result = await _mediator.Send(postProspect);
        //     if (!result.Success)
        //     {
        //         return ReturnFormattedResponse(result);
        //     }
        //     return CreatedAtAction("GetProspectById", new { id = result.Data.Id }, result.Data);
        // }
    }
}
