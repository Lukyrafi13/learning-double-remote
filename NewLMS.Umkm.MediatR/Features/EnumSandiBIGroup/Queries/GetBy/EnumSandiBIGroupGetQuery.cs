using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.EnumSandiBIGroups;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.EnumSandiBIGroups.Queries
{
    public class EnumSandiBIGroupGetQuery : EnumSandiBIGroupFindRequestDto, IRequest<ServiceResponse<EnumSandiBIGroupResponseDto>>
    {
    }

    public class EnumSandiBIGroupGetQueryHandler : IRequestHandler<EnumSandiBIGroupGetQuery, ServiceResponse<EnumSandiBIGroupResponseDto>>
    {
        private IGenericRepositoryAsync<EnumSandiBIGroup> _EnumSandiBIGroup;
        private readonly IMapper _mapper;

        public EnumSandiBIGroupGetQueryHandler(IGenericRepositoryAsync<EnumSandiBIGroup> EnumSandiBIGroup, IMapper mapper)
        {
            _EnumSandiBIGroup = EnumSandiBIGroup;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<EnumSandiBIGroupResponseDto>> Handle(EnumSandiBIGroupGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _EnumSandiBIGroup.GetByIdAsync(request.BI_GROUP, "BI_GROUP");
                if (data == null)
                    return ServiceResponse<EnumSandiBIGroupResponseDto>.Return404("Data EnumSandiBIGroup not found");
                var response = _mapper.Map<EnumSandiBIGroupResponseDto>(data);
                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EnumSandiBIGroupResponseDto>.ReturnException(ex);
            }
        }
    }
}