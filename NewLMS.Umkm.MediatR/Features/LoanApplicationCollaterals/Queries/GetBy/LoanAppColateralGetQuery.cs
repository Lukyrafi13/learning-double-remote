using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Queries
{
    public class LoanAppColateralGetQuery : IRequest<ServiceResponse<AppAgunanResponseDto>>
    {
        public Guid Id { get; set; }
    }

    public class LoanAppColateralGetQueryHandler : IRequestHandler<LoanAppColateralGetQuery, ServiceResponse<AppAgunanResponseDto>>
    {
        private IGenericRepositoryAsync<LoanApplicationCollateral> _core;
        private readonly IMapper _mapper;

        public LoanAppColateralGetQueryHandler(IGenericRepositoryAsync<LoanApplicationCollateral> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppAgunanResponseDto>> Handle(LoanAppColateralGetQuery request, CancellationToken cancellationToken)
        {
            try
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
                var data = await _core.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AppAgunanResponseDto>.Return404("Data Other Finance tidak ditemukan.");
                var dataVm = _mapper.Map<AppAgunanResponseDto>(data);
                return ServiceResponse<AppAgunanResponseDto>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<AppAgunanResponseDto>.ReturnException(ex);
            }

        }
    }
}