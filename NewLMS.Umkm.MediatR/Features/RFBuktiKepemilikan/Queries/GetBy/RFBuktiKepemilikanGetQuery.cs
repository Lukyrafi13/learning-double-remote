using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Queries
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