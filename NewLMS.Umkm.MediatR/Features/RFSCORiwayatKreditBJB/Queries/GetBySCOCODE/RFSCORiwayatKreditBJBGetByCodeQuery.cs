using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCORiwayatKreditBJBs.Queries
{
    public class RFSCORiwayatKreditBJBsGetByCodeQuery : RFSCORiwayatKreditBJBFindRequestDto, IRequest<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {
    }

    public class GetByCodeRFSCORiwayatKreditBJBQueryHandler : IRequestHandler<RFSCORiwayatKreditBJBsGetByCodeQuery, ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCORiwayatKreditBJB> _RFSCORiwayatKreditBJB;
        private readonly IMapper _mapper;

        public GetByCodeRFSCORiwayatKreditBJBQueryHandler(IGenericRepositoryAsync<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJB, IMapper mapper)
        {
            _RFSCORiwayatKreditBJB = RFSCORiwayatKreditBJB;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>> Handle(RFSCORiwayatKreditBJBsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCORiwayatKreditBJB.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.Return404("Data RFSCORiwayatKreditBJB not found");
                var response = _mapper.Map<RFSCORiwayatKreditBJBResponseDto>(data);
                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnException(ex);
            }
        }
    }
}