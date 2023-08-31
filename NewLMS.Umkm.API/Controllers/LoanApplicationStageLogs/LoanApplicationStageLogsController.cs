using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.LoanApplicationStageLogss;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.LoanApplicationStageLogss.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.LoanApplicationStageLogs
{
    public class LoanApplicationStageLogsController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// LoanApplicationStageLogs
        /// </summary>
        /// <param name="mediator"></param>
        public LoanApplicationStageLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get LoanApplicationStageLogs
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetLoanApplicationStageLogsList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<LoanApplicationStageLogsResponseDto>>))]
        public async Task<IActionResult> GetLoanApplicationStageLogsList(LoanApplicationStageLogssGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }
    }
}