using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationPrescreenings.Queries
{
    public class GetLoanApplicationPrescreeningTabDetailQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationPrescreeningResponse>>
    {
    }

    public class GetLoanApplicationPrescreeningTabDetailQueryHandler : IRequestHandler<GetLoanApplicationPrescreeningTabDetailQuery, ServiceResponse<LoanApplicationPrescreeningResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationPrescreeningTabDetailQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationPrescreeningResponse>> Handle(GetLoanApplicationPrescreeningTabDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationPrescreeningIncludes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var data = await _loanApplication.GetByPredicate(x => x.Id == request.Id, loanApplicationPrescreeningIncludes.ToArray());
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationPrescreeningResponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationPrescreeningResponse>(data);

                return ServiceResponse<LoanApplicationPrescreeningResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationPrescreeningResponse>.ReturnException(ex);
            }
        }


    }
}
