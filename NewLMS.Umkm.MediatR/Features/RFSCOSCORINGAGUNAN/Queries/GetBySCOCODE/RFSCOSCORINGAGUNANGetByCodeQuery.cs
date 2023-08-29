using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOSCORINGAGUNANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOSCORINGAGUNANs.Queries
{
    public class RFSCOSCORINGAGUNANsGetByCodeQuery : RFSCOSCORINGAGUNANFindRequestDto, IRequest<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {
    }

    public class GetByCodeRFSCOSCORINGAGUNANQueryHandler : IRequestHandler<RFSCOSCORINGAGUNANsGetByCodeQuery, ServiceResponse<RFSCOSCORINGAGUNANResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> _RFSCOSCORINGAGUNAN;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOSCORINGAGUNANQueryHandler(IGenericRepositoryAsync<RFSCOSCORINGAGUNAN> RFSCOSCORINGAGUNAN, IMapper mapper)
        {
            _RFSCOSCORINGAGUNAN = RFSCOSCORINGAGUNAN;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOSCORINGAGUNANResponseDto>> Handle(RFSCOSCORINGAGUNANsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOSCORINGAGUNAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.Return404("Data RFSCOSCORINGAGUNAN not found");
                var response = _mapper.Map<RFSCOSCORINGAGUNANResponseDto>(data);
                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOSCORINGAGUNANResponseDto>.ReturnException(ex);
            }
        }
    }
}