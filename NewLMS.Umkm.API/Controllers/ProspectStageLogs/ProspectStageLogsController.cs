// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.ProspectStageLogss;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.ProspectStageLogss.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.ProspectStageLogs
// {
//     public class ProspectStageLogsController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// ProspectStageLogs
//         /// </summary>
//         /// <param name="mediator"></param>
//         public ProspectStageLogsController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get ProspectStageLogs
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetProspectStageLogsList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ProspectStageLogsResponseDto>>))]
//         public async Task<IActionResult> GetProspectStageLogsList(ProspectStageLogssGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }
//     }
// }