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
    public class RFBranchInsCompPostCommand : RFBranchInsCompPostRequestDto, IRequest<ServiceResponse<RFBranchInsCompResponseDto>>
    {

    }
    public class RFBranchInsCompPostCommandHandler : IRequestHandler<RFBranchInsCompPostCommand, ServiceResponse<RFBranchInsCompResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBranchInsComp> _RFBranchInsComp;
        private readonly IMapper _mapper;

        public RFBranchInsCompPostCommandHandler(IGenericRepositoryAsync<RFBranchInsComp> RFBranchInsComp, IMapper mapper)
        {
            _RFBranchInsComp = RFBranchInsComp;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBranchInsCompResponseDto>> Handle(RFBranchInsCompPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBranchInsComp = _mapper.Map<RFBranchInsComp>(request);

                var returnedRFBranchInsComp = await _RFBranchInsComp.AddAsync(RFBranchInsComp, callSave: false);

                // var response = _mapper.Map<RFBranchInsCompResponseDto>(returnedRFBranchInsComp);
                var response = _mapper.Map<RFBranchInsCompResponseDto>(returnedRFBranchInsComp);

                await _RFBranchInsComp.SaveChangeAsync();
                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBranchInsCompResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}