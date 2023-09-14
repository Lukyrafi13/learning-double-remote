using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.Data.Dto.Appraisals
{
    public class GetLoanApplicationApprAsignmentTabDetailQuery : LoanApplicationApprGetDetailRequests, IRequest<ServiceResponse<LoanApplicationApprAsignmentResponse>>
    {
    }

    public class GetLoanApplicationApprAsignmentTabDetailQueryHandler : IRequestHandler<GetLoanApplicationApprAsignmentTabDetailQuery, ServiceResponse<LoanApplicationApprAsignmentResponse>>
    {
        private readonly IGenericRepositoryAsync<Appraisal> _appraisal;
        private readonly IMapper _mapper;

        public GetLoanApplicationApprAsignmentTabDetailQueryHandler(
            IGenericRepositoryAsync<Appraisal> appraisal, 
            IMapper mapper)
        {
            _appraisal = appraisal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationApprAsignmentResponse>> Handle(GetLoanApplicationApprAsignmentTabDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var include = new string[]
                {
                    "LoanApplicationCollateral",
                    "LoanApplicationCollateral.LoanApplicationCollateralOwner",
                };
                var data = await _appraisal.GetByPredicate(x => x.LoanApplicationCollateralId == request.LoanApplicationCollateralId, include);
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnResultWith204();
                }

                var dataVm = _mapper.Map<LoanApplicationApprAsignmentResponse>(data);

                return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationApprAsignmentResponse>.ReturnException(ex);
            }
        }
    }
}
