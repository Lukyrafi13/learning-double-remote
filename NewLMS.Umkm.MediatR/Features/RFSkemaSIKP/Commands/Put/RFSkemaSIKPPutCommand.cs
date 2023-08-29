using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSkemaSIKPs.Commands
{
    public class RFSkemaSIKPPutCommand : RFSkemaSIKPPutRequestDto, IRequest<ServiceResponse<RFSkemaSIKPResponseDto>>
    {
    }

    public class PutRFSkemaSIKPCommandHandler : IRequestHandler<RFSkemaSIKPPutCommand, ServiceResponse<RFSkemaSIKPResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public PutRFSkemaSIKPCommandHandler(IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP, IMapper mapper){
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSkemaSIKPResponseDto>> Handle(RFSkemaSIKPPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSkemaSIKP = await _RFSkemaSIKP.GetByIdAsync(request.SkemaCode, "SkemaCode");                
                
                existingRFSkemaSIKP = _mapper.Map<RFSkemaSIKPPutRequestDto, RFSkemaSIKP>(request, existingRFSkemaSIKP);
                
                await _RFSkemaSIKP.UpdateAsync(existingRFSkemaSIKP);

                var response = _mapper.Map<RFSkemaSIKPResponseDto>(existingRFSkemaSIKP);

                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}