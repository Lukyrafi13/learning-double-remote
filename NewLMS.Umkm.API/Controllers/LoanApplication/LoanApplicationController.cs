﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Appraisals.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplicationPrescreenings.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Commands.Processes;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Queries;
using NewLMS.Umkm.MediatR.Features.Prospects.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfInstallmentType
{
    [Authorize]
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

        /// <summary>
        /// Upsert Prescreening
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("prescreening/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertPrescreening(UpsertLoanApplicationPrescreeningCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Process LoanApplication
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("ide/process")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Process([FromBody] ProcessRequest request)
        {
            var command = new LoanApplicationProcessIDE() { AppId = request.Id };

            return Ok(await Mediator.Send(command));
        }


        #region Appraisal Asignment
        //Appraisal Asignment

        /// <summary>
        /// Get List for tables of LoanApplication ApprAsignment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-asignment/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationAppraisalTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterApprAsignment(LoanApplicationAppraisalGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get Detail ApprAsignment by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-asignment/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationApprAsignmentResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailApprAsignment(GetLoanApplicationApprAsignmentTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upsert Appraisal Asignment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("appraisal-asignment/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertApprAsign(UpsertLoanApplicationApprAsignmentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Appraisal Surveyor
        //Appraisal Surveyor

        /// <summary>
        /// Get List for tables of LoanApplication ApprAsignment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-surveyor/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterApprSurveyor(LoanApplicationApprSurveyorGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail LoanApplication by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-surveyor/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<AppraisalSurveyorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailApprSurveyor(GetLoanAppApprSurveyorTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion


        #region Appraisal Approval
        /// <summary>
        /// Get List for tables of LoanApplication ApprApproval
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-approval/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterApprApproval(LoanApplicationApprApprovalGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail LoanApplication by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-approval/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<AppraisalSurveyorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailApprApproval(GetLoanAppApprSurveyorTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region Survey
        //Survey

        /// <summary>
        /// Get List for tables of LoanApplication Survey
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("survey/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationSurveyTabRespone>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterSurveyor(LoanApplicationSurveyGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail Survey by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("survey/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationSurveyResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailSurvey(GetLoanApplicationSurveyTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upsert Survey
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("survey/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertSurvey(UpsertLoanApplicationSurveyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion
    }
    public class ProcessRequest
    {
        public Guid Id { get; set; }
    }
}
