using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationVerificationNeedDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationVerificationNeedDetails.Queries
{
    public class LoanApplicationVerificationNeedDetailsGetByIdQuery : IRequest<ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>>
    {
        public Guid Id { get; set; }
    }

    public class LoanApplicationVerificationNeedDetailsGetByIdQueryHandler : IRequestHandler<LoanApplicationVerificationNeedDetailsGetByIdQuery, ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> _core;
        private readonly IMapper _mapper;

        public LoanApplicationVerificationNeedDetailsGetByIdQueryHandler(IGenericRepositoryAsync<LoanApplicationVerificationNeedDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>> Handle(LoanApplicationVerificationNeedDetailsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>.Return404("Data Key Person tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationVerificationNeedDetailsResponse>(data);
                return ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationVerificationNeedDetailsResponse>.ReturnException(ex);
            }

        }
    }
}
