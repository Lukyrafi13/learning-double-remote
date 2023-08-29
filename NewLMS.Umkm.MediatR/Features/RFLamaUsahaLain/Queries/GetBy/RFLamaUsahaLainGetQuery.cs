using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLamaUsahaLains;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFLamaUsahaLains.Queries
{
    public class RFLamaUsahaLainGetQuery : RFLamaUsahaLainFindRequestDto, IRequest<ServiceResponse<RFLamaUsahaLainResponseDto>>
    {
    }

    public class RFLamaUsahaLainGetQueryHandler : IRequestHandler<RFLamaUsahaLainGetQuery, ServiceResponse<RFLamaUsahaLainResponseDto>>
    {
        private IGenericRepositoryAsync<RFLamaUsahaLain> _RFLamaUsahaLain;
        private readonly IMapper _mapper;

        public RFLamaUsahaLainGetQueryHandler(IGenericRepositoryAsync<RFLamaUsahaLain> RFLamaUsahaLain, IMapper mapper)
        {
            _RFLamaUsahaLain = RFLamaUsahaLain;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFLamaUsahaLainResponseDto>> Handle(RFLamaUsahaLainGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFLamaUsahaLain.GetByIdAsync(request.ANLCode, "ANLCode");
                if (data == null)
                    return ServiceResponse<RFLamaUsahaLainResponseDto>.Return404("Data RFLamaUsahaLain not found");
                var response = _mapper.Map<RFLamaUsahaLainResponseDto>(data);
                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnException(ex);
            }
        }
    }
}