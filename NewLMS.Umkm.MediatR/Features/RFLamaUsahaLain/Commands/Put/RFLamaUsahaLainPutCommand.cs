using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLamaUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLamaUsahaLains.Commands
{
    public class RFLamaUsahaLainPutCommand : RFLamaUsahaLainPutRequestDto, IRequest<ServiceResponse<RFLamaUsahaLainResponseDto>>
    {
    }

    public class RFLamaUsahaLainPutCommandHandler : IRequestHandler<RFLamaUsahaLainPutCommand, ServiceResponse<RFLamaUsahaLainResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLamaUsahaLain> _RFLamaUsahaLain;
        private readonly IMapper _mapper;

        public RFLamaUsahaLainPutCommandHandler(IGenericRepositoryAsync<RFLamaUsahaLain> RFLamaUsahaLain, IMapper mapper)
        {
            _RFLamaUsahaLain = RFLamaUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLamaUsahaLainResponseDto>> Handle(RFLamaUsahaLainPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFLamaUsahaLain = await _RFLamaUsahaLain.GetByIdAsync(request.ANLCode, "ANLCode");
                
                existingRFLamaUsahaLain.ANLDesc = request.ANLDesc;
                existingRFLamaUsahaLain.CoreCode = request.CoreCode;
                existingRFLamaUsahaLain.Active = request.Active;
                await _RFLamaUsahaLain.UpdateAsync(existingRFLamaUsahaLain);

                var response = _mapper.Map<RFLamaUsahaLainResponseDto>(existingRFLamaUsahaLain);

                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLamaUsahaLainResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}