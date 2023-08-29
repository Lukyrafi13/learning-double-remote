using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisLinkAges;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFJenisLinkAges.Queries
{
    public class RFJenisLinkAgeGetQuery : RFJenisLinkAgeFindRequestDto, IRequest<ServiceResponse<RFJenisLinkAgeResponseDto>>
    {
    }

    public class RFJenisLinkAgeGetQueryHandler : IRequestHandler<RFJenisLinkAgeGetQuery, ServiceResponse<RFJenisLinkAgeResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisLinkAge> _RFJenisLinkAge;
        private readonly IMapper _mapper;

        public RFJenisLinkAgeGetQueryHandler(IGenericRepositoryAsync<RFJenisLinkAge> RFJenisLinkAge, IMapper mapper)
        {
            _RFJenisLinkAge = RFJenisLinkAge;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisLinkAgeResponseDto>> Handle(RFJenisLinkAgeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFJenisLinkAge.GetByIdAsync(request.JenisLinkAgeCode, "JenisLinkAgeCode");
                if (data == null)
                    return ServiceResponse<RFJenisLinkAgeResponseDto>.Return404("Data RFJenisLinkAge not found");
                var response = _mapper.Map<RFJenisLinkAgeResponseDto>(data);
                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisLinkAgeResponseDto>.ReturnException(ex);
            }
        }
    }
}