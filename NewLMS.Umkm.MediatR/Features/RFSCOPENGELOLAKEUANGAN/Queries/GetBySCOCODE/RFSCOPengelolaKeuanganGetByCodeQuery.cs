using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Queries
{
    public class RFSCOPENGELOLAKEUANGANGetByCodeQuery : RFSCOPENGELOLAKEUANGANFindRequestDto, IRequest<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {
    }

    public class GetByCodeRFSCOPENGELOLAKEUANGANQueryHandler : IRequestHandler<RFSCOPENGELOLAKEUANGANGetByCodeQuery, ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> _rfSCOPengelolaKeuangan;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOPENGELOLAKEUANGANQueryHandler(IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> rfSCOPengelolaKeuangan, IMapper mapper)
        {
            _rfSCOPengelolaKeuangan = rfSCOPengelolaKeuangan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>> Handle(RFSCOPENGELOLAKEUANGANGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfSCOPengelolaKeuangan.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.Return404("Data RFSCOPENGELOLAKEUANGAN not found");
                var response = _mapper.Map<RFSCOPENGELOLAKEUANGANResponseDto>(data);
                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>.ReturnException(ex);
            }
        }
    }
}