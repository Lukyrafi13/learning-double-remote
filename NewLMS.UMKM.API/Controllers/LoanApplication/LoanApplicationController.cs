﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.LoanApplicationPrescreenings.Queries;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Commands;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Queries;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfInstallmentType
{
    public class LoanApplicationController : BaseController
    {
        /// <summary>
        /// Get List for tables of LoanApplication
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("ide/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilter(GetLoanApplicationListQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail LoanApplication by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("ide/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationIDEResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetail(GetLoanApplicationDetailTabQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Post LoanApplication by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("ide/post")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> PostLoanApp(PostLoanApplicationIDECommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upsert LoanApplication IDE
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("ide/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertIDE(UpsertLoanApplicationIDECommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PreScreening

        /// <summary>
        /// Get List for tables of LoanApplication Prescreening
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterPreScreen(GetLoanApplicationPrescreeningListQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail Prescreening by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("prescreening/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationPrescreeningResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailPrescreening(GetLoanApplicationPrescreeningTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}