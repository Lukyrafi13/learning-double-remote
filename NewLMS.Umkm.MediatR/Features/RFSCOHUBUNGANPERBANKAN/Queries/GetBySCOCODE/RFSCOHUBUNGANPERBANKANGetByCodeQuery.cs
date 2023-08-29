using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Queries
{
    public class RFSCOHUBUNGANPERBANKANsGetByCodeQuery : RFSCOHUBUNGANPERBANKANFindRequestDto, IRequest<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {
    }

    public class GetByCodeRFSCOHUBUNGANPERBANKANQueryHandler : IRequestHandler<RFSCOHUBUNGANPERBANKANsGetByCodeQuery, ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> _RFSCOHUBUNGANPERBANKAN;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOHUBUNGANPERBANKANQueryHandler(IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN, IMapper mapper)
        {
            _RFSCOHUBUNGANPERBANKAN = RFSCOHUBUNGANPERBANKAN;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>> Handle(RFSCOHUBUNGANPERBANKANsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOHUBUNGANPERBANKAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.Return404("Data RFSCOHUBUNGANPERBANKAN not found");
                var response = _mapper.Map<RFSCOHUBUNGANPERBANKANResponseDto>(data);
                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnException(ex);
            }
        }
    }
}