using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFColLateralBCs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFColLateralBCs.Commands
{
    public class RFColLateralBCPostCommand : RFColLateralBCPostRequestDto, IRequest<ServiceResponse<RFColLateralBCResponseDto>>
    {

    }
    public class PostRFColLateralBCCommandHandler : IRequestHandler<RFColLateralBCPostCommand, ServiceResponse<RFColLateralBCResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public PostRFColLateralBCCommandHandler(IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC, IMapper mapper)
        {
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFColLateralBCResponseDto>> Handle(RFColLateralBCPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFColLateralBC = _mapper.Map<RFColLateralBC>(request);

                var returnedRFColLateralBC = await _RFColLateralBC.AddAsync(RFColLateralBC, callSave: false);

                // var response = _mapper.Map<RFColLateralBCResponseDto>(returnedRFColLateralBC);
                var response = _mapper.Map<RFColLateralBCResponseDto>(returnedRFColLateralBC);

                await _RFColLateralBC.SaveChangeAsync();
                return ServiceResponse<RFColLateralBCResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFColLateralBCResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}