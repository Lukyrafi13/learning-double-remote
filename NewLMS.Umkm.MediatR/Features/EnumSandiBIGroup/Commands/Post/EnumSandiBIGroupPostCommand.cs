using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Commands
{
    public class EnumSandiBIGroupPostCommand : EnumSandiBIGroupPostRequestDto, IRequest<ServiceResponse<EnumSandiBIGroupResponseDto>>
    {

    }
    public class EnumSandiBIGroupPostCommandHandler : IRequestHandler<EnumSandiBIGroupPostCommand, ServiceResponse<EnumSandiBIGroupResponseDto>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIGroup> _EnumSandiBIGroup;
        private readonly IMapper _mapper;

        public EnumSandiBIGroupPostCommandHandler(IGenericRepositoryAsync<EnumSandiBIGroup> EnumSandiBIGroup, IMapper mapper)
        {
            _EnumSandiBIGroup = EnumSandiBIGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EnumSandiBIGroupResponseDto>> Handle(EnumSandiBIGroupPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var EnumSandiBIGroup = _mapper.Map<EnumSandiBIGroup>(request);

                var returnedEnumSandiBIGroup = await _EnumSandiBIGroup.AddAsync(EnumSandiBIGroup, callSave: false);

                // var response = _mapper.Map<EnumSandiBIGroupResponseDto>(returnedEnumSandiBIGroup);
                var response = _mapper.Map<EnumSandiBIGroupResponseDto>(returnedEnumSandiBIGroup);

                await _EnumSandiBIGroup.SaveChangeAsync();
                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}