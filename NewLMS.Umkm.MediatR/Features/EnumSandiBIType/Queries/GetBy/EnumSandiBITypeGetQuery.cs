using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Queries
{
    public class EnumSandiBITypeGetQuery : EnumSandiBITypeFindRequestDto, IRequest<ServiceResponse<EnumSandiBITypeResponseDto>>
    {
    }

    public class EnumSandiBITypeGetQueryHandler : IRequestHandler<EnumSandiBITypeGetQuery, ServiceResponse<EnumSandiBITypeResponseDto>>
    {
        private IGenericRepositoryAsync<EnumSandiBIType> _EnumSandiBIType;
        private readonly IMapper _mapper;

        public EnumSandiBITypeGetQueryHandler(IGenericRepositoryAsync<EnumSandiBIType> EnumSandiBIType, IMapper mapper)
        {
            _EnumSandiBIType = EnumSandiBIType;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<EnumSandiBITypeResponseDto>> Handle(EnumSandiBITypeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _EnumSandiBIType.GetByIdAsync(request.BI_TYPE, "BI_TYPE");
                if (data == null)
                    return ServiceResponse<EnumSandiBITypeResponseDto>.Return404("Data EnumSandiBIType not found");
                var response = _mapper.Map<EnumSandiBITypeResponseDto>(data);
                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnException(ex);
            }
        }
    }
}