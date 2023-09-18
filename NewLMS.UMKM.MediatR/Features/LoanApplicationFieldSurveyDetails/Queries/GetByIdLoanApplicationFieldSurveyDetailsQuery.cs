using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationFieldSurveyDetails.Queries
{
    public class GetByIdLoanApplicationFieldSurveyDetailsQuery : IRequest<ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>>
    {
        public Guid Id { get; set; }
    }

    public class GetByIdLoanApplicationFieldSurveyDetailsQueryHandler : IRequestHandler<GetByIdLoanApplicationFieldSurveyDetailsQuery, ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> _core;
        private readonly IMapper _mapper;

        public GetByIdLoanApplicationFieldSurveyDetailsQueryHandler(IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>> Handle(GetByIdLoanApplicationFieldSurveyDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "PaymentMethod"
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>.Return404("Data Key Person tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationFieldSurveyDetailsResponse>(data);
                return ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationFieldSurveyDetailsResponse>.ReturnException(ex);
            }

        }
    }
}
