using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Commands
{
    public class RFVEHICLETYPEPutCommand : RFVEHICLETYPEPutRequestDto, IRequest<ServiceResponse<RFVEHICLETYPEResponseDto>>
    {
    }

    public class PutRFVEHICLETYPECommandHandler : IRequestHandler<RFVEHICLETYPEPutCommand, ServiceResponse<RFVEHICLETYPEResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHICLETYPEs> _RFVEHICLETYPE;
        private readonly IMapper _mapper;

        public PutRFVEHICLETYPECommandHandler(IGenericRepositoryAsync<RFVEHICLETYPEs> RFVEHICLETYPE, IMapper mapper)
        {
            _RFVEHICLETYPE = RFVEHICLETYPE;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHICLETYPEResponseDto>> Handle(RFVEHICLETYPEPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFVEHICLETYPE = await _RFVEHICLETYPE.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
                existingRFVEHICLETYPE.VEH_CODE = request.VEH_CODE;
                existingRFVEHICLETYPE.VEH_DESC = request.VEH_DESC;
                existingRFVEHICLETYPE.CORE_CODE = request.CORE_CODE;
                existingRFVEHICLETYPE.ACTIVE = request.ACTIVE;

                await _RFVEHICLETYPE.UpdateAsync(existingRFVEHICLETYPE);

                var response = _mapper.Map<RFVEHICLETYPEResponseDto>(existingRFVEHICLETYPE);

                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHICLETYPEResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}