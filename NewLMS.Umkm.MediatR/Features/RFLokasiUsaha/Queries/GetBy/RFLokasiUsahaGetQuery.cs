using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLokasiUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiUsahas.Queries
{
    public class RFLokasiUsahaGetQuery : RFLokasiUsahaFindRequestDto, IRequest<ServiceResponse<RFLokasiUsahaResponseDto>>
    {
    }

    public class RFLokasiUsahaGetQueryHandler : IRequestHandler<RFLokasiUsahaGetQuery, ServiceResponse<RFLokasiUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFLokasiUsaha> _RFLokasiUsaha;
        private readonly IMapper _mapper;

        public RFLokasiUsahaGetQueryHandler(IGenericRepositoryAsync<RFLokasiUsaha> RFLokasiUsaha, IMapper mapper)
        {
            _RFLokasiUsaha = RFLokasiUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFLokasiUsahaResponseDto>> Handle(RFLokasiUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFLokasiUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFLokasiUsahaResponseDto>.Return404("Data RFLokasiUsaha not found");
                var response = _mapper.Map<RFLokasiUsahaResponseDto>(data);
                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}