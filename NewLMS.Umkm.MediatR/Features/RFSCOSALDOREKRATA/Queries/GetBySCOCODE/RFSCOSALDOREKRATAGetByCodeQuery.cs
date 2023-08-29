using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Queries
{
    public class RFSCOSALDOREKRATAsGetByCodeQuery : RFSCOSALDOREKRATAFindRequestDto, IRequest<ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {
    }

    public class GetByCodeRFSCOSALDOREKRATAQueryHandler : IRequestHandler<RFSCOSALDOREKRATAsGetByCodeQuery, ServiceResponse<RFSCOSALDOREKRATAResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOSALDOREKRATA> _RFSCOSALDOREKRATA;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOSALDOREKRATAQueryHandler(IGenericRepositoryAsync<RFSCOSALDOREKRATA> RFSCOSALDOREKRATA, IMapper mapper)
        {
            _RFSCOSALDOREKRATA = RFSCOSALDOREKRATA;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOSALDOREKRATAResponseDto>> Handle(RFSCOSALDOREKRATAsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOSALDOREKRATA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.Return404("Data RFSCOSALDOREKRATA not found");
                var response = _mapper.Map<RFSCOSALDOREKRATAResponseDto>(data);
                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSALDOREKRATAResponseDto>.ReturnException(ex);
            }
        }
    }
}