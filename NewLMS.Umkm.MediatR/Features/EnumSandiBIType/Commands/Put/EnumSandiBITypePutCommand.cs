using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.EnumSandiBITypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBITypes.Commands
{
    public class EnumSandiBITypePutCommand : EnumSandiBITypePutRequestDto, IRequest<ServiceResponse<EnumSandiBITypeResponseDto>>
    {
    }

    public class PutEnumSandiBITypeCommandHandler : IRequestHandler<EnumSandiBITypePutCommand, ServiceResponse<EnumSandiBITypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIType> _EnumSandiBIType;
        private readonly IMapper _mapper;

        public PutEnumSandiBITypeCommandHandler(IGenericRepositoryAsync<EnumSandiBIType> EnumSandiBIType, IMapper mapper)
        {
            _EnumSandiBIType = EnumSandiBIType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EnumSandiBITypeResponseDto>> Handle(EnumSandiBITypePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEnumSandiBIType = await _EnumSandiBIType.GetByIdAsync(request.BI_TYPE, "BI_TYPE");
                
                existingEnumSandiBIType.BI_TYPE = request.BI_TYPE;
                existingEnumSandiBIType.BI_TYPEDESC = request.BI_TYPEDESC;
                
                await _EnumSandiBIType.UpdateAsync(existingEnumSandiBIType);

                var response = _mapper.Map<EnumSandiBITypeResponseDto>(existingEnumSandiBIType);

                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}