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
    public class UpsertLoanApplicationApprAsignmentCommand : AppraisalPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationApprAsignmentCommandHandler : IRequestHandler<UpsertLoanApplicationApprAsignmentCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IGenericRepositoryAsync<LoanApplicationCollateral> _loanApplicationCollateral;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationApprAsignmentCommandHandler(
            IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal,
            IGenericRepositoryAsync<LoanApplicationCollateral> loanApplicationCollateral,
            IMapper mapper)
        {
            _appraisal = appraisal;
            _loanApplicationCollateral = loanApplicationCollateral;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationApprAsignmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprAsigment = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId);
                if (apprAsigment != null)
                {
                    apprAsigment.PropertyCategory = request.PropertyCategory;
                    apprAsigment.isInternal = request.isInternal;
                    apprAsigment.isExternal = request.isExternal;
                    apprAsigment.Estimator = request.Estimator;
                    apprAsigment.Kjpp = request.Kjpp;
                    apprAsigment.AppraisalStatus = request.AppraisalStatus;
                }
                await _appraisal.UpdateAsync(apprAsigment);

                //cek Perubahan Agunan
                var loanApplicationCollateralData = await _loanApplicationCollateral.GetByPredicate(x => x.Id == apprAsigment.LoanApplicationCollateralId);
                if(request.CollateralCode != loanApplicationCollateralData.CollateralBCId)
                {
                    loanApplicationCollateralData.CollateralBCId = request.CollateralCode;
                    await _loanApplicationCollateral.UpdateAsync(loanApplicationCollateralData);
                }
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
