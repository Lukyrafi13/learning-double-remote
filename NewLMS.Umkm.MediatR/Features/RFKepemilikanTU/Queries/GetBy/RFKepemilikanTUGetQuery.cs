using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Queries
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