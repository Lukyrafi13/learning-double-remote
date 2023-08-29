using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTipeDokumens;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFTipeDokumens.Queries
{
    public class RFTipeDokumenGetQuery : RFTipeDokumenFindRequestDto, IRequest<ServiceResponse<RFTipeDokumenResponseDto>>
    {
    }

    public class RFTipeDokumenGetQueryHandler : IRequestHandler<RFTipeDokumenGetQuery, ServiceResponse<RFTipeDokumenResponseDto>>
    {
        private IGenericRepositoryAsync<RFTipeDokumen> _RFTipeDokumen;
        private readonly IMapper _mapper;

        public RFTipeDokumenGetQueryHandler(IGenericRepositoryAsync<RFTipeDokumen> RFTipeDokumen, IMapper mapper)
        {
            _RFTipeDokumen = RFTipeDokumen;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTipeDokumenResponseDto>> Handle(RFTipeDokumenGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFTipeDokumen.GetByIdAsync(request.TypeCode, "TypeCode");
                if (data == null)
                    return ServiceResponse<RFTipeDokumenResponseDto>.Return404("Data RFTipeDokumen not found");
                var response = _mapper.Map<RFTipeDokumenResponseDto>(data);
                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeDokumenResponseDto>.ReturnException(ex);
            }
        }
    }
}