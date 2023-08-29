using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLokasiTempatUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFLokasiTempatUsahas.Queries
{
    public class RFLokasiTempatUsahaGetQuery : RFLokasiTempatUsahaFindRequestDto, IRequest<ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {
    }

    public class RFLokasiTempatUsahaGetQueryHandler : IRequestHandler<RFLokasiTempatUsahaGetQuery, ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFLokasiTempatUsaha> _RFLokasiTempatUsaha;
        private readonly IMapper _mapper;

        public RFLokasiTempatUsahaGetQueryHandler(IGenericRepositoryAsync<RFLokasiTempatUsaha> RFLokasiTempatUsaha, IMapper mapper)
        {
            _RFLokasiTempatUsaha = RFLokasiTempatUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFLokasiTempatUsahaResponseDto>> Handle(RFLokasiTempatUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFLokasiTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFLokasiTempatUsahaResponseDto>.Return404("Data RFLokasiTempatUsaha not found");
                var response = _mapper.Map<RFLokasiTempatUsahaResponseDto>(data);
                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}