using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationAnalysts;
using NewLMS.Umkm.Data.Dto.LoanApplications;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationAnalysts.Queries
{
    public class LoanApplicationAnalystsGetDetailQuery : LoanApplicationGetDetailTabRequest, IRequest<ServiceResponse<LoanApplicationAnalystReponse>>
    {
    }

    public class LoanApplicationAnalystsGetDetailQueryHandler : IRequestHandler<LoanApplicationAnalystsGetDetailQuery, ServiceResponse<LoanApplicationAnalystReponse>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IMapper _mapper;

        public LoanApplicationAnalystsGetDetailQueryHandler(IGenericRepositoryAsync<LoanApplication> loanApplication, IMapper mapper)
        {
            _loanApplication = loanApplication;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationAnalystReponse>> Handle(LoanApplicationAnalystsGetDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationPrescreeningIncludes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var data = await _loanApplication.GetByPredicate(x => x.Id == request.Id, loanApplicationPrescreeningIncludes.ToArray());
                if (data == null)
                {
                    return ServiceResponse<LoanApplicationAnalystReponse>.ReturnResultWith204();
                }
                else
                {
                    data.MappingTab = request.Tab;
                }

                var dataVm = _mapper.Map<LoanApplicationAnalystReponse>(data);

                return ServiceResponse<LoanApplicationAnalystReponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationAnalystReponse>.ReturnException(ex);
            }
        }


    }
}
