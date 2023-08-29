using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Queries
{
    public class RFSCOTINGKATKEBUTUHANsGetByCodeQuery : RFSCOTINGKATKEBUTUHANFindRequestDto, IRequest<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {
    }

    public class GetByCodeRFSCOTINGKATKEBUTUHANQueryHandler : IRequestHandler<RFSCOTINGKATKEBUTUHANsGetByCodeQuery, ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> _RFSCOTINGKATKEBUTUHAN;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOTINGKATKEBUTUHANQueryHandler(IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN, IMapper mapper)
        {
            _RFSCOTINGKATKEBUTUHAN = RFSCOTINGKATKEBUTUHAN;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>> Handle(RFSCOTINGKATKEBUTUHANsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOTINGKATKEBUTUHAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.Return404("Data RFSCOTINGKATKEBUTUHAN not found");
                var response = _mapper.Map<RFSCOTINGKATKEBUTUHANResponseDto>(data);
                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnException(ex);
            }
        }
    }
}