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
    public class EnumSandiBIGroupPutCommand : EnumSandiBIGroupPutRequestDto, IRequest<ServiceResponse<EnumSandiBIGroupResponseDto>>
    {
    }

    public class PutEnumSandiBIGroupCommandHandler : IRequestHandler<EnumSandiBIGroupPutCommand, ServiceResponse<EnumSandiBIGroupResponseDto>>
    {
        private readonly IGenericRepositoryAsync<EnumSandiBIGroup> _EnumSandiBIGroup;
        private readonly IMapper _mapper;

        public PutEnumSandiBIGroupCommandHandler(IGenericRepositoryAsync<EnumSandiBIGroup> EnumSandiBIGroup, IMapper mapper)
        {
            _EnumSandiBIGroup = EnumSandiBIGroup;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<EnumSandiBIGroupResponseDto>> Handle(EnumSandiBIGroupPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingEnumSandiBIGroup = await _EnumSandiBIGroup.GetByIdAsync(request.BI_GROUP, "BI_GROUP");
                
                existingEnumSandiBIGroup.BI_GROUP = request.BI_GROUP;
                existingEnumSandiBIGroup.BI_GROUPDESC = request.BI_GROUPDESC;
                
                await _EnumSandiBIGroup.UpdateAsync(existingEnumSandiBIGroup);

                var response = _mapper.Map<EnumSandiBIGroupResponseDto>(existingEnumSandiBIGroup);

                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}