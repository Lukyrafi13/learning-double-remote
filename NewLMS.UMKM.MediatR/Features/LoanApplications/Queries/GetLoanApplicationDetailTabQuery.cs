using AutoMapper;
using MediatR;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Data.Dto.LoanApplications;
using NewLMS.UMKM.MediatR.Helpers;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class GetLoanApplicationDetailTabQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationIDEResponse>>
    {
    }

    public class GetLoanApplicationDetailTabQueryHandler : IRequestHandler<GetLoanApplicationDetailTabQuery, ServiceResponse<LoanApplicationIDEResponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public GetLoanApplicationDetailTabQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationIDEResponse>> Handle(GetLoanApplicationDetailTabQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationIncludes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var data = await _loanApplication.GetByIdAsync(request.Id, "Id", loanApplicationIncludes.ToArray());
                if (data == null)
                {

                    return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationIDEResponse>(data);
                if(dataVm.Info.OwnerCategoryId == 1)
                {
                    dataVm.Info.FullName = data.Debtor.Fullname;
                }
                if (dataVm.Info.OwnerCategoryId == 2)
                {
                    dataVm.Info.FullName = data.DebtorCompany.Name;
                }

                return ServiceResponse<LoanApplicationIDEResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationIDEResponse>.ReturnException(ex);
            }
        }

        
    }
}