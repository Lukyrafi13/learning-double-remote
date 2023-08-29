using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTipeKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTipeKredits.Commands
{
    public class RFTipeKreditPutCommand : RFTipeKreditPutRequestDto, IRequest<ServiceResponse<RFTipeKreditResponseDto>>
    {
    }

    public class PutRFTipeKreditCommandHandler : IRequestHandler<RFTipeKreditPutCommand, ServiceResponse<RFTipeKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTipeKredit> _RFTipeKredit;
        private readonly IMapper _mapper;

        public PutRFTipeKreditCommandHandler(IGenericRepositoryAsync<RFTipeKredit> RFTipeKredit, IMapper mapper)
        {
            _RFTipeKredit = RFTipeKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTipeKreditResponseDto>> Handle(RFTipeKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTipeKredit = await _RFTipeKredit.GetByIdAsync(request.Code, "Code");
                
                existingRFTipeKredit = _mapper.Map<RFTipeKreditPutRequestDto, RFTipeKredit>(request, existingRFTipeKredit);
                
                await _RFTipeKredit.UpdateAsync(existingRFTipeKredit);

                var response = _mapper.Map<RFTipeKreditResponseDto>(existingRFTipeKredit);

                return ServiceResponse<RFTipeKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}