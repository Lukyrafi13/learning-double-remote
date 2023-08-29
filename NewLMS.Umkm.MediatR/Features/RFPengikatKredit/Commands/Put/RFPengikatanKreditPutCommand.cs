using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPengikatanKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPengikatanKredits.Commands
{
    public class RFPengikatanKreditPutCommand : RFPengikatanKreditPutRequestDto, IRequest<ServiceResponse<RFPengikatanKreditResponseDto>>
    {
    }

    public class PutRFPengikatanKreditCommandHandler : IRequestHandler<RFPengikatanKreditPutCommand, ServiceResponse<RFPengikatanKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPengikatanKredit> _RFPengikatanKredit;
        private readonly IMapper _mapper;

        public PutRFPengikatanKreditCommandHandler(IGenericRepositoryAsync<RFPengikatanKredit> RFPengikatanKredit, IMapper mapper)
        {
            _RFPengikatanKredit = RFPengikatanKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPengikatanKreditResponseDto>> Handle(RFPengikatanKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFPengikatanKredit = await _RFPengikatanKredit.GetByIdAsync(request.PK_CODE, "PK_CODE");

                existingRFPengikatanKredit.PK_CODE = request.PK_CODE;
                existingRFPengikatanKredit.PK_DESC = request.PK_DESC;
                existingRFPengikatanKredit.CORE_CODE = request.CORE_CODE;
                existingRFPengikatanKredit.ACTIVE = request.ACTIVE;

                await _RFPengikatanKredit.UpdateAsync(existingRFPengikatanKredit);

                var response = _mapper.Map<RFPengikatanKreditResponseDto>(existingRFPengikatanKredit);

                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}