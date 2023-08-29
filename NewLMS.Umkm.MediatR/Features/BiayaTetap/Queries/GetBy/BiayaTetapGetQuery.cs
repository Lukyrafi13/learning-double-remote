using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.BiayaTetaps.Queries
{
    public class BiayaTetapGetQuery : BiayaTetapFindRequestDto, IRequest<ServiceResponse<BiayaTetapResponseDto>>
    {
    }

    public class BiayaTetapGetQueryHandler : IRequestHandler<BiayaTetapGetQuery, ServiceResponse<BiayaTetapResponseDto>>
    {
        private IGenericRepositoryAsync<BiayaTetap> _BiayaTetap;
        private readonly IMapper _mapper;

        public BiayaTetapGetQueryHandler(IGenericRepositoryAsync<BiayaTetap> BiayaTetap, IMapper mapper)
        {
            _BiayaTetap = BiayaTetap;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<BiayaTetapResponseDto>> Handle(BiayaTetapGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _BiayaTetap.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<BiayaTetapResponseDto>.Return404("Data BiayaTetap not found");
                var response = _mapper.Map<BiayaTetapResponseDto>(data);
                return ServiceResponse<BiayaTetapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaTetapResponseDto>.ReturnException(ex);
            }
        }
    }
}