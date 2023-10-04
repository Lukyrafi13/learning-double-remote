using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Constants;
using NewLMS.Umkm.Data.Dto.LoanApplicationStageProcess;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationStageProcess.Commands
{
    public class ProcessLoanApplicationPrescreening : LoanApplicationProcessStageRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class ProcessLoanApplicationPrescreeningHandler : IRequestHandler<ProcessLoanApplicationPrescreening, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationStage> _loanStage;
        private readonly UserContext _userContext;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public ProcessLoanApplicationPrescreeningHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IMapper mapper,
            UserContext userContext,
            ICurrentUserService currentUser,
            IGenericRepositoryAsync<LoanApplicationStage> loanStage)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
            _userContext = userContext;
            _currentUser = currentUser;
            _loanStage = loanStage;
        }

        public async Task<ServiceResponse<Unit>> Handle(ProcessLoanApplicationPrescreening request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]
                    {
                        "SLIKRequest"
                    };
                var loanApplication = await _loanApplication.GetByPredicate(x => x.Id == request.Id, includes);
                if (loanApplication.SLIKRequest != null && !loanApplication.SLIKRequest.AdminVerified)
                {
                    return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, "Data belum diverifikasi oleh admin untuk proses SLIK, Gagal Dipreses.");
                }

                if (loanApplication != null)
                {
                    #region LoanStage Logging
                    var prevQuery = _userContext.Set<LoanApplicationStage>().AsQueryable();
                    var prevLoanApplicationStage = prevQuery.Where(x => x.LoanApplicationId == loanApplication.Id && x.StageId == UMKMConst.Stages["Prescreening"] && x.Processed == false).OrderByDescending(x => x.CreatedDate).FirstOrDefault();

                    if (prevLoanApplicationStage != null)
                    {
                        prevLoanApplicationStage.Processed = true;
                        prevLoanApplicationStage.ProcessedBy = Guid.Parse(_currentUser.Id);
                        prevLoanApplicationStage.ProcessedDate = DateTime.Now;
                        await _loanStage.UpdateAsync(prevLoanApplicationStage);
                    }

                    LoanApplicationStage loanApplicationStage = LoanApplicationHelper.CreateLoanApplicationStage(loanApplication, Guid.Parse(_currentUser.Id), UMKMConst.Stages["Survey"], loanApplication.CreatedBy, UMKMConst.Roles["AccountOfficerUMKM"]);

                    await _loanStage.AddAsync(loanApplicationStage);
                    #endregion


                    loanApplication.StageId = UMKMConst.Stages["Survey"];
                    loanApplication = LoanApplicationHelper.ClearLoanApplicationRelatives(loanApplication);
                    await _loanApplication.UpdateAsync(loanApplication);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data Tidak Ditemukan, Gagal Proses Stage");
                }


                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
