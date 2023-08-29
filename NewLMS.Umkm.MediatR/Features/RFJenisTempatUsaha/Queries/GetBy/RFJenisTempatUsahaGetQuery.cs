using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisTempatUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisTempatUsahas.Queries
{
    public class RFJenisTempatUsahaGetQuery : RFJenisTempatUsahaFindRequestDto, IRequest<ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {
    }

    public class RFJenisTempatUsahaGetQueryHandler : IRequestHandler<RFJenisTempatUsahaGetQuery, ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisTempatUsaha> _RFJenisTempatUsaha;
        private readonly IMapper _mapper;

        public RFJenisTempatUsahaGetQueryHandler(IGenericRepositoryAsync<RFJenisTempatUsaha> RFJenisTempatUsaha, IMapper mapper)
        {
            _RFJenisTempatUsaha = RFJenisTempatUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisTempatUsahaResponseDto>> Handle(RFJenisTempatUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJenisTempatUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFJenisTempatUsahaResponseDto>.Return404("Data RFJenisTempatUsaha not found");
                var response = _mapper.Map<RFJenisTempatUsahaResponseDto>(data);
                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}