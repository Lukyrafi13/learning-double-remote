using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTempalateAkadKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTempalateAkadKredits.Commands
{
    public class RFTempalateAkadKreditPostCommand : RFTempalateAkadKreditPostRequestDto, IRequest<ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {

    }
    public class PostRFTempalateAkadKreditCommandHandler : IRequestHandler<RFTempalateAkadKreditPostCommand, ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTempalateAkadKredit> _RFTempalateAkadKredit;
        private readonly IMapper _mapper;

        public PostRFTempalateAkadKreditCommandHandler(IGenericRepositoryAsync<RFTempalateAkadKredit> RFTempalateAkadKredit, IMapper mapper)
        {
            _RFTempalateAkadKredit = RFTempalateAkadKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTempalateAkadKreditResponseDto>> Handle(RFTempalateAkadKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTempalateAkadKredit = _mapper.Map<RFTempalateAkadKredit>(request);

                var returnedRFTempalateAkadKredit = await _RFTempalateAkadKredit.AddAsync(RFTempalateAkadKredit, callSave: false);

                // var response = _mapper.Map<RFTempalateAkadKreditResponseDto>(returnedRFTempalateAkadKredit);
                var response = _mapper.Map<RFTempalateAkadKreditResponseDto>(returnedRFTempalateAkadKredit);

                await _RFTempalateAkadKredit.SaveChangeAsync();
                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}