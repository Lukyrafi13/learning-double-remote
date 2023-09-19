using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationCycleDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationCycleDetails.Queries
{
    public class GetByIdLoanApplicationVerificationCycleDetailQuery : IRequest<ServiceResponse<LoanApplicationVerificationCycleDetailResponse>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdLoanApplicationVerificationCycleDetailQueryHandler : IRequestHandler<GetByIdLoanApplicationVerificationCycleDetailQuery, ServiceResponse<LoanApplicationVerificationCycleDetailResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> _core;
        private readonly IMapper _mapper;

        public GetByIdLoanApplicationVerificationCycleDetailQueryHandler(IGenericRepositoryAsync<LoanApplicationVerificationCycleDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationVerificationCycleDetailResponse>> Handle(GetByIdLoanApplicationVerificationCycleDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationVerificationCycleDetailResponse>.Return404("Data Key Person tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationVerificationCycleDetailResponse>(data);
                return ServiceResponse<LoanApplicationVerificationCycleDetailResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationVerificationCycleDetailResponse>.ReturnException(ex);
            }

        }
    }
}
