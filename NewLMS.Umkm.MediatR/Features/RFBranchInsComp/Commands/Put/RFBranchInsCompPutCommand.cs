using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBranchInsComps;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBranchInsComps.Commands
{
    public class RFBranchInsCompPutCommand : RFBranchInsCompPutRequestDto, IRequest<ServiceResponse<RFBranchInsCompResponseDto>>
    {
    }

    public class PutRFBranchInsCompCommandHandler : IRequestHandler<RFBranchInsCompPutCommand, ServiceResponse<RFBranchInsCompResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBranchInsComp> _RFBranchInsComp;
        private readonly IMapper _mapper;

        public PutRFBranchInsCompCommandHandler(IGenericRepositoryAsync<RFBranchInsComp> RFBranchInsComp, IMapper mapper)
        {
            _RFBranchInsComp = RFBranchInsComp;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBranchInsCompResponseDto>> Handle(RFBranchInsCompPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBranchInsComp = await _RFBranchInsComp.GetByIdAsync(request.Id, "Id");
                
                existingRFBranchInsComp = _mapper.Map<RFBranchInsCompPutRequestDto, RFBranchInsComp>(request, existingRFBranchInsComp);
                
                await _RFBranchInsComp.UpdateAsync(existingRFBranchInsComp);

                var response = _mapper.Map<RFBranchInsCompResponseDto>(existingRFBranchInsComp);

                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}