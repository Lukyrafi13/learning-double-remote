using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Dto.LoanApplicationSurvey;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationSurvey.Queries
{
    public class GetLoanApplicationSurveyTabDetailQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationSurveyResponse>>
    {
    }

    public class GetLoanApplicationSurveyTabDetailQueryHandler : IRequestHandler<GetLoanApplicationSurveyTabDetailQuery, ServiceResponse<LoanApplicationSurveyResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationSurveyTabDetailQueryHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationSurveyResponse>> Handle(GetLoanApplicationSurveyTabDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationIncludes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var data = await _loanApplication.GetByIdAsync(request.Id, "Id", loanApplicationIncludes.ToArray());
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationSurveyResponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationSurveyResponse>(data);

                return ServiceResponse<LoanApplicationSurveyResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationSurveyResponse>.ReturnException(ex);
            }
        }
    }
}
