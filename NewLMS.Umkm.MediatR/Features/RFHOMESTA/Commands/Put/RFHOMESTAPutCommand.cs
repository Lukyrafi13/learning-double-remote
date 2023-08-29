using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFHOMESTAs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFHOMESTAs.Commands
{
    public class RFHOMESTAPutCommand : RFHOMESTAPutRequestDto, IRequest<ServiceResponse<RFHOMESTAResponseDto>>
    {
    }

    public class PutRFHOMESTACommandHandler : IRequestHandler<RFHOMESTAPutCommand, ServiceResponse<RFHOMESTAResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFHOMESTA> _RFHOMESTA;
        private readonly IMapper _mapper;

        public PutRFHOMESTACommandHandler(IGenericRepositoryAsync<RFHOMESTA> RFHOMESTA, IMapper mapper){
            _RFHOMESTA = RFHOMESTA;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFHOMESTAResponseDto>> Handle(RFHOMESTAPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFHOMESTA = await _RFHOMESTA.GetByIdAsync(request.HMSTA_CODE, "HMSTA_CODE");
                existingRFHOMESTA.HMSTA_CODE = request.HMSTA_CODE;
                existingRFHOMESTA.HMSTA_DESC = request.HMSTA_DESC;
                existingRFHOMESTA.CORE_CODE = request.CORE_CODE;
                existingRFHOMESTA.ACTIVE = request.ACTIVE;
                
                await _RFHOMESTA.UpdateAsync(existingRFHOMESTA);

                var response = _mapper.Map<RFHOMESTAResponseDto>(existingRFHOMESTA);

                return ServiceResponse<RFHOMESTAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFHOMESTAResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}