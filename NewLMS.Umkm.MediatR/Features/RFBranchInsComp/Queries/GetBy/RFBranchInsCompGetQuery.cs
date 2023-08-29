using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBranchInsComps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFBranchInsComps.Queries
{
    public class RFBranchInsCompGetQuery : RFBranchInsCompFindRequestDto, IRequest<ServiceResponse<RFBranchInsCompResponseDto>>
    {
    }

    public class RFBranchInsCompGetQueryHandler : IRequestHandler<RFBranchInsCompGetQuery, ServiceResponse<RFBranchInsCompResponseDto>>
    {
        private IGenericRepositoryAsync<RFBranchInsComp> _RFBranchInsComp;
        private readonly IMapper _mapper;

        public RFBranchInsCompGetQueryHandler(IGenericRepositoryAsync<RFBranchInsComp> RFBranchInsComp, IMapper mapper)
        {
            _RFBranchInsComp = RFBranchInsComp;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBranchInsCompResponseDto>> Handle(RFBranchInsCompGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFBranchInsComp.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFBranchInsCompResponseDto>.Return404("Data RFBranchInsComp not found");
                var response = _mapper.Map<RFBranchInsCompResponseDto>(data);
                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnException(ex);
            }
        }
    }
}