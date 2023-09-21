using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Appraisals;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Commands
{
    public class UpsertLoanApplicationApprSurveyorCommand : AppraisalSurveyorUpsertRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationApprSurveyorCommandHandler : IRequestHandler<UpsertLoanApplicationApprSurveyorCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationApprSurveyorCommandHandler(
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral,
            IMapper mapper)
        {
            _loanApplicationCollateral = loanApplicationCollateral;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationApprSurveyorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //cek Perubahan Agunan
                var loanApplicationCollateralData = await _loanApplicationCollateral.GetByPredicate(x => x.Id == request.LoanApplicationCollateralId);
                if (request.CollateralCode != loanApplicationCollateralData.CollateralBCId)
                {
                    loanApplicationCollateralData.CollateralBCId = request.CollateralCode;
                    await _loanApplicationCollateral.UpdateAsync(loanApplicationCollateralData);
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
