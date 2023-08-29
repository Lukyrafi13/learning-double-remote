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
    public class RFPengikatanKreditPostCommand : RFPengikatanKreditPostRequestDto, IRequest<ServiceResponse<RFPengikatanKreditResponseDto>>
    {

    }
    public class RFPengikatanKreditPostCommandHandler : IRequestHandler<RFPengikatanKreditPostCommand, ServiceResponse<RFPengikatanKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFPengikatanKredit> _RFPengikatanKredit;
        private readonly IMapper _mapper;

        public RFPengikatanKreditPostCommandHandler(IGenericRepositoryAsync<RFPengikatanKredit> RFPengikatanKredit, IMapper mapper)
        {
            _RFPengikatanKredit = RFPengikatanKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFPengikatanKreditResponseDto>> Handle(RFPengikatanKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFPengikatanKredit = _mapper.Map<RFPengikatanKredit>(request);

                var returnedRFPengikatanKredit = await _RFPengikatanKredit.AddAsync(RFPengikatanKredit, callSave: false);

                // var response = _mapper.Map<RFPengikatanKreditResponseDto>(returnedRFPengikatanKredit);
                var response = _mapper.Map<RFPengikatanKreditResponseDto>(returnedRFPengikatanKredit);

                await _RFPengikatanKredit.SaveChangeAsync();
                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPengikatanKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}