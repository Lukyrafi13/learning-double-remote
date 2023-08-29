using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Queries
{
    public class RFKelompokUsahaGetQuery : RFKelompokUsahaFindRequestDto, IRequest<ServiceResponse<RFKelompokUsahaResponseDto>>
    {
    }

    public class RFKelompokUsahaGetQueryHandler : IRequestHandler<RFKelompokUsahaGetQuery, ServiceResponse<RFKelompokUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFKelompokUsaha> _RFKelompokUsaha;
        private readonly IMapper _mapper;

        public RFKelompokUsahaGetQueryHandler(IGenericRepositoryAsync<RFKelompokUsaha> RFKelompokUsaha, IMapper mapper)
        {
            _RFKelompokUsaha = RFKelompokUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFKelompokUsahaResponseDto>> Handle(RFKelompokUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFKelompokUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFKelompokUsahaResponseDto>.Return404("Data RFKelompokUsaha not found");
                var response = _mapper.Map<RFKelompokUsahaResponseDto>(data);
                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}