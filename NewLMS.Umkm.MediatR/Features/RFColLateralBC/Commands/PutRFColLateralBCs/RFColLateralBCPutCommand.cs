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
    public class RFColLateralBCPutCommand : RFColLateralBCPutRequestDto, IRequest<ServiceResponse<RFColLateralBCResponseDto>>
    {
    }

    public class PutRFColLateralBCCommandHandler : IRequestHandler<RFColLateralBCPutCommand, ServiceResponse<RFColLateralBCResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public PutRFColLateralBCCommandHandler(IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC, IMapper mapper){
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFColLateralBCResponseDto>> Handle(RFColLateralBCPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFColLateralBC = await _RFColLateralBC.GetByIdAsync(request.ColCode, "ColCode");
                existingRFColLateralBC.ColCode = request.ColCode;
                existingRFColLateralBC.ColDesc = request.ColDesc;
                existingRFColLateralBC.ColType = request.ColType;
                existingRFColLateralBC.ColcatCode = request.ColcatCode;
                existingRFColLateralBC.CoreCode = request.CoreCode;
                existingRFColLateralBC.Land = request.Land;
                existingRFColLateralBC.Building = request.Building;
                existingRFColLateralBC.BeaGroup = request.BeaGroup;
                existingRFColLateralBC.Active = request.Active;
                
                await _RFColLateralBC.UpdateAsync(existingRFColLateralBC);

                var response = _mapper.Map<RFColLateralBCResponseDto>(existingRFColLateralBC);

                return ServiceResponse<RFColLateralBCResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFColLateralBCResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}