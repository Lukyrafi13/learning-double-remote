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
    public class EnumSandiBITypePostCommand : EnumSandiBITypePostRequestDto, IRequest<ServiceResponse<EnumSandiBITypeResponseDto>>
    {

    }
    public class EnumSandiBITypePostCommandHandler : IRequestHandler<EnumSandiBITypePostCommand, ServiceResponse<EnumSandiBITypeResponseDto>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIType> _EnumSandiBIType;
        private readonly IMapper _mapper;

        public EnumSandiBITypePostCommandHandler(IGenericRepositoryAsync<EnumSandiBIType> EnumSandiBIType, IMapper mapper)
        {
            _EnumSandiBIType = EnumSandiBIType;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EnumSandiBITypeResponseDto>> Handle(EnumSandiBITypePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var EnumSandiBIType = _mapper.Map<EnumSandiBIType>(request);

                var returnedEnumSandiBIType = await _EnumSandiBIType.AddAsync(EnumSandiBIType, callSave: false);

                // var response = _mapper.Map<EnumSandiBITypeResponseDto>(returnedEnumSandiBIType);
                var response = _mapper.Map<EnumSandiBITypeResponseDto>(returnedEnumSandiBIType);

                await _EnumSandiBIType.SaveChangeAsync();
                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBITypeResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}