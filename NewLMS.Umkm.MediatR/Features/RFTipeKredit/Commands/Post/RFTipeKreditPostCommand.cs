using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTipeKredits.Commands
{
    public class RFTipeKreditPostCommand : RFTipeKreditPostRequestDto, IRequest<ServiceResponse<RFTipeKreditResponseDto>>
    {

    }
    public class RFTipeKreditPostCommandHandler : IRequestHandler<RFTipeKreditPostCommand, ServiceResponse<RFTipeKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTipeKredit> _RFTipeKredit;
        private readonly IMapper _mapper;

        public RFTipeKreditPostCommandHandler(IGenericRepositoryAsync<RFTipeKredit> RFTipeKredit, IMapper mapper)
        {
            _RFTipeKredit = RFTipeKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTipeKreditResponseDto>> Handle(RFTipeKreditPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTipeKredit = _mapper.Map<RFTipeKredit>(request);

                var returnedRFTipeKredit = await _RFTipeKredit.AddAsync(RFTipeKredit, callSave: false);

                // var response = _mapper.Map<RFTipeKreditResponseDto>(returnedRFTipeKredit);
                var response = _mapper.Map<RFTipeKreditResponseDto>(returnedRFTipeKredit);

                await _RFTipeKredit.SaveChangeAsync();
                return ServiceResponse<RFTipeKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTipeKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}