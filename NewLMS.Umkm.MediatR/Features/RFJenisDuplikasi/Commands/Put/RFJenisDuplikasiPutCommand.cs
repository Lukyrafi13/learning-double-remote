using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Commands
{
    public class RFJenisDuplikasiPutCommand : RFJenisDuplikasiPutRequestDto, IRequest<ServiceResponse<RFJenisDuplikasiResponseDto>>
    {
    }

    public class RFJenisDuplikasiPutCommandHandler : IRequestHandler<RFJenisDuplikasiPutCommand, ServiceResponse<RFJenisDuplikasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        private readonly IMapper _mapper;

        public RFJenisDuplikasiPutCommandHandler(IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi, IMapper mapper)
        {
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisDuplikasiResponseDto>> Handle(RFJenisDuplikasiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisDuplikasi = await _RFJenisDuplikasi.GetByIdAsync(request.JenisCode, "JenisCode");
                
                existingRFJenisDuplikasi = _mapper.Map<RFJenisDuplikasiPutRequestDto, RFJenisDuplikasi>(request, existingRFJenisDuplikasi);
                
                await _RFJenisDuplikasi.UpdateAsync(existingRFJenisDuplikasi);

                var response = _mapper.Map<RFJenisDuplikasiResponseDto>(existingRFJenisDuplikasi);

                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}