using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Queries
{
    public class RFStatusDokumenGetQuery : RFStatusDokumenFindRequestDto, IRequest<ServiceResponse<RFStatusDokumenResponseDto>>
    {
    }

    public class RFStatusDokumenGetQueryHandler : IRequestHandler<RFStatusDokumenGetQuery, ServiceResponse<RFStatusDokumenResponseDto>>
    {
        private IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IMapper _mapper;

        public RFStatusDokumenGetQueryHandler(IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen, IMapper mapper)
        {
            _RFStatusDokumen = RFStatusDokumen;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFStatusDokumenResponseDto>> Handle(RFStatusDokumenGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFStatusDokumen.GetByIdAsync(request.StatusCode, "StatusCode");
                if (data == null)
                    return ServiceResponse<RFStatusDokumenResponseDto>.Return404("Data RFStatusDokumen not found");
                var response = _mapper.Map<RFStatusDokumenResponseDto>(data);
                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnException(ex);
            }
        }
    }
}