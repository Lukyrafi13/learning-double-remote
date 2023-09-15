using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplications.Commands
{
    public class UpsertLoanApplicationApprAsignmentCommand : AppraisalPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationApprAsignmentCommandHandler : IRequestHandler<UpsertLoanApplicationApprAsignmentCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appraisal;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationApprAsignmentCommandHandler(IGenericRepositoryAsync<LoanApplicationAppraisal> appraisal,
        IMapper mapper)
        {
            _appraisal = appraisal;
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

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
