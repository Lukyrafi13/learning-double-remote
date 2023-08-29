using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBusinessTypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFBusinessTypes.Queries
{
    public class RFBusinessTypeGetQuery : RFBusinessTypeFindRequestDto, IRequest<ServiceResponse<RFBusinessTypeResponseDto>>
    {
    }

    public class RFBusinessTypeGetQueryHandler : IRequestHandler<RFBusinessTypeGetQuery, ServiceResponse<RFBusinessTypeResponseDto>>
    {
        private IGenericRepositoryAsync<RFBusinessType> _RFBusinessType;
        private readonly IMapper _mapper;

        public RFBusinessTypeGetQueryHandler(IGenericRepositoryAsync<RFBusinessType> RFBusinessType, IMapper mapper)
        {
            _RFBusinessType = RFBusinessType;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBusinessTypeResponseDto>> Handle(RFBusinessTypeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFBusinessType.GetByIdAsync(request.BTCode, "BTCode");
                if (data == null)
                    return ServiceResponse<RFBusinessTypeResponseDto>.Return404("Data RFBusinessType not found");
                var response = _mapper.Map<RFBusinessTypeResponseDto>(data);
                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBusinessTypeResponseDto>.ReturnException(ex);
            }
        }
    }
}