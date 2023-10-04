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
    public class SLIKRequestAKBLProcessCommand : IRequest<ServiceResponse<Unit>>
    {
        public Guid Id { get; set; }
        public double TotalCreditCard { get; set; }
        public double TotalLimitSlik { get; set; }
        public double TotalOtherUses { get; set; }
        public double TotalWorkingCapital { get; set; }
    }

    public class SLIKRequestAKBLProcessCommandHandler : IRequestHandler<SLIKRequestAKBLProcessCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SLIKRequest> _slikRequest;
        private readonly IGenericRepositoryAsync<LoanApplicationStage> _loanStage;
        private readonly ICurrentUserService _currentUser;
        private readonly UserContext _userContext;

        public SLIKRequestAKBLProcessCommandHandler(IGenericRepositoryAsync<SLIKRequest> slikRequest, IGenericRepositoryAsync<LoanApplicationStage> loanStage, ICurrentUserService currentUser, UserContext userContext)
        {
            _slikRequest = slikRequest;
            _loanStage = loanStage;
            _currentUser = currentUser;
            _userContext = userContext;
        }

        public async Task<ServiceResponse<Unit>> Handle(SLIKRequestAKBLProcessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var slikRequest = await _slikRequest.GetByIdAsync(request.Id, "Id", new string[] { "LoanApplication" }) ?? throw new NullReferenceException("Data SLIK tidak ditemukan.");

                slikRequest.Status = Data.Enums.EnumSLIKStatus.Processed;
                slikRequest.AdminVerified = true;
                slikRequest.ReadAndUnderstand = true;
                slikRequest.TotalCreditCard = request.TotalCreditCard;
                slikRequest.TotalLimitSlik = request.TotalLimitSlik;
                slikRequest.TotalOtherUses = request.TotalOtherUses;
                slikRequest.TotalWorkingCapital = request.TotalWorkingCapital;

                #region LoanStage Logging
                var prevQuery = _userContext.Set<LoanApplicationStage>().AsQueryable();
                var prevLoanApplicationStage = prevQuery.Where(x => x.LoanApplicationId == slikRequest.Id && x.StageId == UMKMConst.Stages["SLIKRequestAKBL"] && x.Processed == false).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

                if (prevLoanApplicationStage != null)
                {
                    prevLoanApplicationStage.Processed = true;
                    prevLoanApplicationStage.ProcessedBy = Guid.Parse(_currentUser.Id);
                    prevLoanApplicationStage.ProcessedDate = DateTime.Now;
                    await _loanStage.UpdateAsync(prevLoanApplicationStage);
                }

                //Don't Create new log
                //LoanApplicationStage loanApplicationStage = LoanApplicationHelper.CreateLoanApplicationStage(slikRequest.LoanApplication, Guid.Parse(_currentUser.Id), UMKMConst.Stages["SLIKAdmin"], null, UMKMConst.Roles["AdministrasiOperasional"]);
                //await _loanStage.AddAsync(loanApplicationStage);
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
