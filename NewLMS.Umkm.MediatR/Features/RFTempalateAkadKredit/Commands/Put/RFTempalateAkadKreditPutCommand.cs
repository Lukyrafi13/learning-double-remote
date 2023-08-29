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
    public class RFTempalateAkadKreditPutCommand : RFTempalateAkadKreditPutRequestDto, IRequest<ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {
    }

    public class PutRFTempalateAkadKreditCommandHandler : IRequestHandler<RFTempalateAkadKreditPutCommand, ServiceResponse<RFTempalateAkadKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTempalateAkadKredit> _RFTempalateAkadKredit;
        private readonly IMapper _mapper;

        public PutRFTempalateAkadKreditCommandHandler(IGenericRepositoryAsync<RFTempalateAkadKredit> RFTempalateAkadKredit, IMapper mapper)
        {
            _RFTempalateAkadKredit = RFTempalateAkadKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTempalateAkadKreditResponseDto>> Handle(RFTempalateAkadKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTempalateAkadKredit = await _RFTempalateAkadKredit.GetByIdAsync(request.TermDesc, "TermDesc");
                existingRFTempalateAkadKredit.Urutan = request.Urutan;
                existingRFTempalateAkadKredit.TermDesc = request.TermDesc;

                await _RFTempalateAkadKredit.UpdateAsync(existingRFTempalateAkadKredit);

                var response = _mapper.Map<RFTempalateAkadKreditResponseDto>(existingRFTempalateAkadKredit);

                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTempalateAkadKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}