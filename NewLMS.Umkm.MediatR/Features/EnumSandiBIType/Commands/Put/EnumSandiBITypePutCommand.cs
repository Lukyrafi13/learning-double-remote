using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Commands
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