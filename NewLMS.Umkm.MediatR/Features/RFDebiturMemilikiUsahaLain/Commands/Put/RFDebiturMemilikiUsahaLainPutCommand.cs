using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Commands
{
    public class RFDebiturMemilikiUsahaLainPutCommand : RFDebiturMemilikiUsahaLainPutRequestDto, IRequest<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {
    }

    public class PutRFDebiturMemilikiUsahaLainCommandHandler : IRequestHandler<RFDebiturMemilikiUsahaLainPutCommand, ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>>
    {
        private readonly IGenericRepositoryAsync<DebiturMemilikiUsahaLain> _RFDebiturMemilikiUsahaLain;
        private readonly IMapper _mapper;

        public PutRFDebiturMemilikiUsahaLainCommandHandler(IGenericRepositoryAsync<DebiturMemilikiUsahaLain> RFDebiturMemilikiUsahaLain, IMapper mapper)
        {
            _RFDebiturMemilikiUsahaLain = RFDebiturMemilikiUsahaLain;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>> Handle(RFDebiturMemilikiUsahaLainPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFDebiturMemilikiUsahaLain = await _RFDebiturMemilikiUsahaLain.GetByIdAsync(request.StatusDebitur_Code, "StatusDebitur_Code");
                existingRFDebiturMemilikiUsahaLain.StatusDebitur_Code = request.StatusDebitur_Code;
                existingRFDebiturMemilikiUsahaLain.StatusDebitur_Desc = request.StatusDebitur_Desc;

                await _RFDebiturMemilikiUsahaLain.UpdateAsync(existingRFDebiturMemilikiUsahaLain);

                var response = _mapper.Map<RFDebiturMemilikiUsahaLainResponseDto>(existingRFDebiturMemilikiUsahaLain);

                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDebiturMemilikiUsahaLainResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}