using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKepemilikanTUs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFKepemilikanTUs.Queries
{
    public class RFKepemilikanTUGetQuery : RFKepemilikanTUFindRequestDto, IRequest<ServiceResponse<RFKepemilikanTUResponseDto>>
    {
    }

    public class RFKepemilikanTUGetQueryHandler : IRequestHandler<RFKepemilikanTUGetQuery, ServiceResponse<RFKepemilikanTUResponseDto>>
    {
        private IGenericRepositoryAsync<RFKepemilikanTU> _RFKepemilikanTU;
        private readonly IMapper _mapper;

        public RFKepemilikanTUGetQueryHandler(IGenericRepositoryAsync<RFKepemilikanTU> RFKepemilikanTU, IMapper mapper)
        {
            _RFKepemilikanTU = RFKepemilikanTU;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFKepemilikanTUResponseDto>> Handle(RFKepemilikanTUGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFKepemilikanTU.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFKepemilikanTUResponseDto>.Return404("Data RFKepemilikanTU not found");
                var response = _mapper.Map<RFKepemilikanTUResponseDto>(data);
                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanTUResponseDto>.ReturnException(ex);
            }
        }
    }
}