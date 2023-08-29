using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.Prospects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.Prospects.Commands;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.Prospect
{
    public class ProspectController : BaseController
    {
        public IMediator _mediator { get; set; }

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
        [Produces("application/json", "application/xml", Type = typeof(ProspectResponseDto))]
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
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ProspectResponseDto>>))]
        public async Task<IActionResult> GetProspectList(ProspectsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New Prospect
        /// </summary>
        /// <param name="postProspect"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddProspect")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectResponseDto>))]
        public async Task<IActionResult> AddProspect(ProspectPostCommand postProspect)
        {
            var result = await _mediator.Send(postProspect);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetProspectById", new { id = result.Data.Id }, result.Data);
        }

        

        // /// <summary>
        // /// Process Prospect
        // /// </summary>
        // /// <param name="postProsesProspect"></param>
        // /// <returns></returns>
        // [HttpPost("proses", Name = "ProsesProspect")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectProsesResponseDto>))]
        // public async Task<IActionResult> ProsesProspect(ProspectProsesCommand postProsesProspect)
        // {
        //     var result = await _mediator.Send(postProsesProspect);
        //     if (!result.Success)
        //     {
        //         return ReturnFormattedResponse(result);
        //     }
        //     return Ok(result);
        // }

        // /// <summary>
        // /// Process Prospect
        // /// </summary>
        // /// <param name="postProsesUlangProspect"></param>
        // /// <returns></returns>
        // [HttpPost("proses/ulang", Name = "ProsesUlangProspect")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectProsesResponseDto>))]
        // public async Task<IActionResult> ProsesUlangProspect(ProspectProsesUlangCommand postProsesUlangProspect)
        // {
        //     var result = await _mediator.Send(postProsesUlangProspect);
        //     if (!result.Success)
        //     {
        //         return ReturnFormattedResponse(result);
        //     }
        //     return Ok(result);
        // }

        // /// <summary>
        // /// Tidak Process Prospect
        // /// </summary>
        // /// <param name="postTidakProsesProspect"></param>
        // /// <returns></returns>
        // [HttpPost("tidak-proses", Name = "TidakProsesProspect")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectProsesResponseDto>))]
        // public async Task<IActionResult> TidakProsesProspect(ProspectTidakProsesCommand postTidakProsesProspect)
        // {
        //     var result = await _mediator.Send(postTidakProsesProspect);
        //     if (!result.Success)
        //     {
        //         return ReturnFormattedResponse(result);
        //     }
        //     return Ok(result);
        // }

        /// <summary>
        /// Put Edit Prospect
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putProspect"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditProspect")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ProspectResponseDto>))]
        public async Task<IActionResult> EditProspect([FromRoute] string Id, [FromBody] ProspectPutCommand putProspect)
        {
            putProspect.Id = Id;
            var result = await _mediator.Send(putProspect);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete Prospect
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteProspect")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteProspect([FromRoute] string Id, [FromBody]ProspectDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}