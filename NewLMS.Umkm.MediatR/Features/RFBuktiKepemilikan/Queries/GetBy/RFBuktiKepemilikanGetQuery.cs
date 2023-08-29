using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBuktiKepemilikans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFBuktiKepemilikans.Queries
{
    public class RFBuktiKepemilikanGetQuery : RFBuktiKepemilikanFindRequestDto, IRequest<ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {
    }

    public class RFBuktiKepemilikanGetQueryHandler : IRequestHandler<RFBuktiKepemilikanGetQuery, ServiceResponse<RFBuktiKepemilikanResponseDto>>
    {
        private IGenericRepositoryAsync<RFBuktiKepemilikan> _RFBuktiKepemilikan;
        private readonly IMapper _mapper;

        public RFBuktiKepemilikanGetQueryHandler(IGenericRepositoryAsync<RFBuktiKepemilikan> RFBuktiKepemilikan, IMapper mapper)
        {
            _RFBuktiKepemilikan = RFBuktiKepemilikan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBuktiKepemilikanResponseDto>> Handle(RFBuktiKepemilikanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFBuktiKepemilikan.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFBuktiKepemilikanResponseDto>.Return404("Data RFBuktiKepemilikan not found");
                var response = _mapper.Map<RFBuktiKepemilikanResponseDto>(data);
                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBuktiKepemilikanResponseDto>.ReturnException(ex);
            }
        }
    }
}