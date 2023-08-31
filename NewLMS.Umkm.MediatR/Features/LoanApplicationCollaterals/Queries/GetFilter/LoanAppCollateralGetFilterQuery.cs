using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Queries
{
    public class LoanAppCollateralGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppAgunanResponseDto>>>
    {
    }

    public class LoanAppCollateralGetFilterQueryHandler : IRequestHandler<LoanAppCollateralGetFilterQuery, PagedResponse<IEnumerable<AppAgunanResponseDto>>>
    {
        private IGenericRepositoryAsync<LoanApplicationCollateral> _core;
        private readonly IMapper _mapper;

        public LoanAppCollateralGetFilterQueryHandler(IGenericRepositoryAsync<LoanApplicationCollateral> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AppAgunanResponseDto>>> Handle(LoanAppCollateralGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                    "RfZipCodeCollateral",
                    "RfZipCode",
                    "RfZipCodeCouple",
                    "RfAppType",
                    "RFMappingAgunan2",
                    "ParamVehTypeCollateral",
                    "RFDocument",
                    "RFVEHMAKER",
                    "RFVEHCLASS",
                    "RFVehModel",
                    "ParamRealationCol",
                    "MaritalId",
                    "ParamDeedType",
                };
            var data = await _core.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<AppAgunanResponseDto>>(data.Results);
            return new PagedResponse<IEnumerable<AppAgunanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}