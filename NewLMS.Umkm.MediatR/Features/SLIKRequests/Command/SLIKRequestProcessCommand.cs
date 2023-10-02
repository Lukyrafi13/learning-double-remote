using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.SLIKRequests.Commands
{
    public class SLIKRequestProcessCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid Id { get; set; }
    }

    public class SLIKRequestProcessCommandHandler : IRequestHandler<SLIKRequestProcessCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IGenericRepositoryAsync<LoanApplicationStage> _loanStage;
        private readonly ICurrentUserService _currentUser;
        private readonly UserContext _userContext;

        public SLIKRequestProcessCommandHandler(IGenericRepositoryAsync<SLIKRequest> slikRequest, ICurrentUserService currentUser, UserContext userContext, IGenericRepositoryAsync<LoanApplicationStage> loanStage)
        {
            _slikRequest = slikRequest;
            _currentUser = currentUser;
            _userContext = userContext;
            _loanStage = loanStage;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestProcessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequest = await _slikRequest.GetByIdAsync(request.Id, "Id", new string[] { "LoanApplication" }) ?? throw new NullReferenceException("Data SLIK tidak ditemukan.");
                slikRequest.StageId = UMKMConst.Stages["SLIKRequestAKBL"];

                #region LoanStage Logging
                var prevQuery = _userContext.Set<LoanApplicationStage>().AsQueryable();
                var prevLoanApplicationStage = prevQuery.Where(x => x.LoanApplicationId == slikRequest.Id && x.StageId == UMKMConst.Stages["SLIKRequest"] && x.Processed == false).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

                if (prevLoanApplicationStage != null)
                {
                    prevLoanApplicationStage.Processed = true;
                    prevLoanApplicationStage.ProcessedBy = Guid.Parse(_currentUser.Id);
                    prevLoanApplicationStage.ProcessedDate = DateTime.Now;
                    await _loanStage.UpdateAsync(prevLoanApplicationStage);
                }

                LoanApplicationStage loanApplicationStageSLIK = LoanApplicationHelper.CreateLoanApplicationStage(slikRequest.LoanApplication, Guid.Parse(_currentUser.Id), UMKMConst.Stages["SLIKRequestAKBL"], null, UMKMConst.Roles["AdministrasiOperasional"]);
                LoanApplicationStage loanApplicationStagePrescreen = LoanApplicationHelper.CreateLoanApplicationStage(slikRequest.LoanApplication, Guid.Parse(_currentUser.Id), UMKMConst.Stages["Prescreening"], slikRequest.LoanApplication.CreatedBy, UMKMConst.Roles["AccountOfficerUMKM"]);

                await _loanStage.AddAsync(loanApplicationStageSLIK);
                await _loanStage.AddAsync(loanApplicationStagePrescreen);
                #endregion

                await _slikRequest.UpdateAsync(slikRequest);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
