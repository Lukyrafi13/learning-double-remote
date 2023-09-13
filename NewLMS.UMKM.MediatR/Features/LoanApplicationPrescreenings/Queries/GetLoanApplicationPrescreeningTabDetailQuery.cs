using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Helpers;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationPrescreenings.Queries
{
    public class GetLoanApplicationPrescreeningTabDetailQuery : LoanApplicationGetPrescreeningDetailTabRequest, IRequest<ServiceResponse<LoanApplicationPrescreeningResponse>>
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
                var loanApplicationPrescreeningIncludes = IncludesGenerator.GetLoanApplicationPrescreeningIncludes(request.Tab);
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
