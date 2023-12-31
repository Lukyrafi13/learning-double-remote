﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts;
using NewLMS.Umkm.Data.Dto.LoanApplicationDuplication;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.Appraisals.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplicationAnalysts.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplicationAnalysts.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplicationPrescreenings.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Commands.Processes;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Queries;
using NewLMS.Umkm.MediatR.Features.LoanApplications.Queries.GetDuplicationLoanApplication;
using NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Commands;
using NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Queries;
using NewLMS.Umkm.MediatR.Features.Prospects.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.LoanApplciations
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

        #region Prescreening

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

        #endregion

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

        #region Duplication
        /// <summary>
        /// Get LoanApplication's Duplications (Local)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Duplication/{Id}")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationDuplicationResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Duplication([FromRoute] Guid Id)
        {
            var command = new GetDuplicationLoanApplicationQuery() { LoanApplicationGuid = Id };

            return Ok(await Mediator.Send(command));
        }
        #endregion


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

        /// <summary>
        /// Get List for tables of LoanApplication ApprSuveyor
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
        /// Get detail LoanApplication Surveyor by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-surveyor/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationApprSurveyorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailApprSurveyor(GetLoanAppApprSurveyorTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upsert Appraisal Surveyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("appraisal-surveyor/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertApprSurveyor(UpsertLoanApplicationApprSurveyorCommand command)
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

        #region Analyst

        /// <summary>
        /// Get List for tables of LoanApplication ApprSuveyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("analyst/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationAnalystTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterAnalyst(LoanApplicationAnalystGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail LoanApplication Surveyor by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("analyst/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationAnalystReponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailAnalyst(LoanApplicationAnalystsGetDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upsert Analyst
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("analyst/upsert")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<Unit>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> UpsertAnalyst(UpsertLoanApplicationAnalystCommand command)
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
