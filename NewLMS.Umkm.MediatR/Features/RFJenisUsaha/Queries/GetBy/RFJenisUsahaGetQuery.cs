using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Queries
{
    public class RFJenisUsahaGetQuery : RFJenisUsahaFindRequestDto, IRequest<ServiceResponse<RFJenisUsahaResponseDto>>
    {
    }

    public class RFJenisUsahaGetQueryHandler : IRequestHandler<RFJenisUsahaGetQuery, ServiceResponse<RFJenisUsahaResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public RFJenisUsahaGetQueryHandler(IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisUsahaResponseDto>> Handle(RFJenisUsahaGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJenisUsaha.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFJenisUsahaResponseDto>.Return404("Data RFJenisUsaha not found");
                var response = _mapper.Map<RFJenisUsahaResponseDto>(data);
                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnException(ex);
            }
        }
    }
}