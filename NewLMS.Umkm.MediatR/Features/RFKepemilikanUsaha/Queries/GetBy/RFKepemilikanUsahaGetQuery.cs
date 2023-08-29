using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanUsahas.Queries
{
    public class RFKepemilikanUsahaGetQuery : RFKepemilikanUsahaFindRequestDto, IRequest<ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {
    }

    public class RFKepemilikanUsahaGetQueryHandler : IRequestHandler<RFKepemilikanUsahaGetQuery, ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFKepemilikanUsaha> _RFKepemilikanUsaha;
        private readonly IMapper _mapper;

        public RFKepemilikanUsahaGetQueryHandler(IGenericRepositoryAsync<RFKepemilikanUsaha> RFKepemilikanUsaha, IMapper mapper)
        {
            _RFKepemilikanUsaha = RFKepemilikanUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFKepemilikanUsahaResponseDto>> Handle(RFKepemilikanUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFKepemilikanUsaha.GetByIdAsync(request.KepemilikanUsahaId, "KepemilikanUsahaId");
                if (data == null)
                    return ServiceResponse<RFKepemilikanUsahaResponseDto>.Return404("Data RFKepemilikanUsaha not found");
                var response = _mapper.Map<RFKepemilikanUsahaResponseDto>(data);
                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}