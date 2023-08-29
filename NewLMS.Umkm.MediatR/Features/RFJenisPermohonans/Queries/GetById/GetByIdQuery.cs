using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Queries
{
    public class RfAppTypesGetByIdQuery : RfAppTypeFindRequestDto, IRequest<ServiceResponse<RfAppTypeResponseDto>>
    {
    }

    public class GetByIdRfAppTypeQueryHandler : IRequestHandler<RfAppTypesGetByIdQuery, ServiceResponse<RfAppTypeResponseDto>>
    {
        private IGenericRepositoryAsync<RfAppType> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public GetByIdRfAppTypeQueryHandler(IGenericRepositoryAsync<RfAppType> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfAppTypeResponseDto>> Handle(RfAppTypesGetByIdQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfJenisPermohonan.GetByIdAsync(request.Id, "Id");

            var response = _mapper.Map<RfAppTypeResponseDto>(data);
            
            return ServiceResponse<RfAppTypeResponseDto>.ReturnResultWith200(response);
        }
    }
}