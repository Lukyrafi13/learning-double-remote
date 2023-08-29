using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Commands;
using NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCompanyType
{
    public class RfCompanyTypeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCompanyType
        /// </summary>
        /// <param name="mediator"></param>
        public RfCompanyTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCompanyType By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRfCompanyTypeById")]
        [Produces("application/json", "application/xml", Type = typeof(RfCompanyTypeResponseDto))]
        public async Task<IActionResult> GetRfCompanyTypeById(string AnlCode)
        {
            var getGenderQuery = new RfCompanyTypeGetQuery { AnlCode = AnlCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCompanyType
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCompanyTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCompanyTypeResponseDto>>))]
        public async Task<IActionResult> GetRfCompanyTypeList(RfCompanyTypesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCompanyType
        /// </summary>
        /// <param name="postRfCompanyType"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCompanyType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeResponseDto>))]
        public async Task<IActionResult> AddRfCompanyType(RfCompanyTypePostCommand postRfCompanyType)
        {
            var result = await _mediator.Send(postRfCompanyType);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCompanyTypeById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCompanyType
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRfCompanyType"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRfCompanyType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyTypeResponseDto>))]
        public async Task<IActionResult> EditRfCompanyType([FromRoute] string AnlCode, [FromBody] RfCompanyTypePutCommand putRfCompanyType)
        {
            putRfCompanyType.AnlCode = AnlCode;
            var result = await _mediator.Send(putRfCompanyType);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCompanyType
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRfCompanyType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCompanyType([FromRoute] string AnlCode, [FromBody] RfCompanyTypeDeleteCommand deleteCommand)
        {
            deleteCommand.AnlCode = AnlCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}