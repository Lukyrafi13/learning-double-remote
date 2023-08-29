using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFMappingLBU3s;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Commands;
using NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFMappingLBU3
{
    public class RFMappingLBU3Controller : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFMappingLBU3
        /// </summary>
        /// <param name="mediator"></param>
        public RFMappingLBU3Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFMappingLBU3 By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFMappingLBU3By")]
        [Produces("application/json", "application/xml", Type = typeof(RFMappingLBU3ResponseDto))]
        public async Task<IActionResult> GetRFMappingLBU3By(int Id)
        {
            var getGenderQuery = new RFMappingLBU3GetQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFMappingLBU3 By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFMappingLBU3List")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFMappingLBU3ResponseDto>>))]
        public async Task<IActionResult> GetRFMappingLBU3List(RFMappingLBU3sGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Get RfSectorLBU3 By SectorLBU2 and ProductId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("sector/get", Name = "GetRfSectorLBU3List")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfSectorLBU3Response>>))]
        public async Task<IActionResult> GetRfSectorLBU3List(RfSectorLBU3sGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFMappingLBU3
        /// </summary>
        /// <param name="postRFMappingLBU3"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFMappingLBU3")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingLBU3ResponseDto>))]
        public async Task<IActionResult> AddRFMappingLBU3(RFMappingLBU3PostCommand postRFMappingLBU3)
        {
            var result = await _mediator.Send(postRFMappingLBU3);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFMappingLBU3ById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFMappingLBU3
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFMappingLBU3"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFMappingLBU3")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingLBU3ResponseDto>))]
        public async Task<IActionResult> EditRFMappingLBU3([FromRoute] int Id, [FromBody] RFMappingLBU3PutCommand putRFMappingLBU3)
        {
            putRFMappingLBU3.Id = Id;
            var result = await _mediator.Send(putRFMappingLBU3);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFMappingLBU3
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFMappingLBU3")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFMappingLBU3([FromRoute] int Id, [FromBody]RFMappingLBU3DeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}