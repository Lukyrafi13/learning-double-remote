using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Dto.LoanApplicationSurvey;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Appraisals.Queries;
using NewLMS.UMKM.MediatR.Features.LoanApplicationPrescreenings.Queries;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Commands;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Commands.Processes;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Queries;
using NewLMS.UMKM.MediatR.Features.LoanApplicationSurveyor.Queries;
using NewLMS.UMKM.MediatR.Features.Prospects.Queries;
using System;
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

        //Appraisal Surveyor
         
        /// <summary>
        /// Get List for tables of LoanApplication ApprAsignment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("appraisal-surveyor/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationApprSurveyorTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterApprSurveyor(LoanApplicationSurveyGetTableQuery command)
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

        //Surveyor

        /// <summary>
        /// Get List for tables of LoanApplication Surveyor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationPrescreeningsTableResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterSurveyor(LoanApplicationSurveyGetTableQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get detail Surveyor by Tab
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("surveyor/get/detail")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<LoanApplicationSurveyResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDetailSurveyor(GetLoanApplicationSurveyTabDetailQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
    public class ProcessRequest
    {
        public Guid Id { get; set; }
    }
}
