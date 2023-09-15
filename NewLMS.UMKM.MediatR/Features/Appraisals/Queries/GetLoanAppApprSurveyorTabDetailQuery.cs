using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class GetLoanAppApprSurveyorTabDetailQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationIDEResponse>>
    {
    }

    public class GetLoanAppApprSurveyorTabDetailQueryHandler : IRequestHandler<GetLoanAppApprSurveyorTabDetailQuery, ServiceResponse<LoanApplicationIDEResponse>>
    {
        private readonly IGenericRepositoryAsync<Appraisal> _appraisal;
        private readonly IMapper _mapper;

        public GetLoanAppApprSurveyorTabDetailQueryHandler(IGenericRepositoryAsync<Appraisal> appraisal, IMapper mapper)
        {
            _appraisal = appraisal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationIDEResponse>> Handle(GetLoanAppApprSurveyorTabDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationIncludes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var data = await _appraisal.GetByIdAsync(request.Id, "Id", loanApplicationIncludes.ToArray());
                if (data == null)
                {

                    return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationIDEResponse>(data);

                return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationIDEResponse>.ReturnException(ex);
            }
        }


    }
}
