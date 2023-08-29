// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Commands;
// using NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.EnumSandiBIGroup
// {
//     public class EnumSandiBIGroupController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// EnumSandiBIGroup
//         /// </summary>
//         /// <param name="mediator"></param>
//         public EnumSandiBIGroupController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get EnumSandiBIGroup By BI_GROUP
//         /// </summary>
//         /// <param name="BI_GROUP"></param>
//         /// <returns></returns>
//         [HttpGet("get/{BI_GROUP}", Name = "GetEnumSandiBIGroupByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(EnumSandiBIGroupResponseDto))]
//         public async Task<IActionResult> GetEnumSandiBIGroupByCode(string BI_GROUP)
//         {
//             var getSCOQuery = new EnumSandiBIGroupGetQuery { BI_GROUP = BI_GROUP };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get EnumSandiBIGroup
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetEnumSandiBIGroupList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<EnumSandiBIGroupResponseDto>>))]
//         public async Task<IActionResult> GetEnumSandiBIGroupList(EnumSandiBIGroupsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New EnumSandiBIGroup
//         /// </summary>
//         /// <param name="postEnumSandiBIGroup"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddEnumSandiBIGroup")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<EnumSandiBIGroupResponseDto>))]
//         public async Task<IActionResult> AddEnumSandiBIGroup(EnumSandiBIGroupPostCommand postEnumSandiBIGroup)
//         {
//             var result = await _mediator.Send(postEnumSandiBIGroup);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetEnumSandiBIGroupByCode", new { BI_GROUP = result.Data.BI_GROUP }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit EnumSandiBIGroup
//         /// </summary>
//         /// <param name="BI_GROUP"></param>
//         /// <param name="putEnumSandiBIGroup"></param>
//         /// <returns></returns>
//         [HttpPut("put/{BI_GROUP}", Name = "EditEnumSandiBIGroup")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<EnumSandiBIGroupResponseDto>))]
//         public async Task<IActionResult> EditEnumSandiBIGroup([FromRoute] string BI_GROUP, [FromBody] EnumSandiBIGroupPutCommand putEnumSandiBIGroup)
//         {
//             putEnumSandiBIGroup.BI_GROUP = BI_GROUP;
//             var result = await _mediator.Send(putEnumSandiBIGroup);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete EnumSandiBIGroup
//         /// </summary>
//         /// <param name="BI_GROUP"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{BI_GROUP}", Name = "DeleteEnumSandiBIGroup")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteEnumSandiBIGroup([FromRoute] string BI_GROUP, [FromBody]EnumSandiBIGroupDeleteCommand deleteCommand)
//         {
//             deleteCommand.BI_GROUP = BI_GROUP;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }