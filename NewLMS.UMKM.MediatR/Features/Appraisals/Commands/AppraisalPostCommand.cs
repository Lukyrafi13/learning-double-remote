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

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Commands
{
    public class AppraisalPostCommand : AppraisalPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostAppraisalCommandHandler : IRequestHandler<AppraisalPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationAppraisal> _appr;
        private readonly IMapper _mapper;

        public PostAppraisalCommandHandler(IGenericRepositoryAsync<LoanApplicationAppraisal> appr,
        IMapper mapper)
        {
            _appr = appr;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(AppraisalPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apprEntity = new LoanApplicationAppraisal
                {
                    AppraisalId = Guid.NewGuid(),
                    LoanApplicationCollateralId = request.LoanApplicationCollateralId,
                    isInternal = request.isInternal,
                    isExternal = request.isExternal,
                    Kjpp = request.Kjpp,
                    Estimator = request.Estimator,
                    PropertyCategory = request.PropertyCategory

                };
                await _appr.AddAsync(apprEntity);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
