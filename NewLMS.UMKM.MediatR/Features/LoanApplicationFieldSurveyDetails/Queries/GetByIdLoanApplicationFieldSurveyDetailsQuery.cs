using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationFieldSurveyDetails.Queries
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
