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
    public class RFJenisDuplikasiPostCommand : RFJenisDuplikasiPostRequestDto, IRequest<ServiceResponse<RFJenisDuplikasiResponseDto>>
    {

    }
    public class RFJenisDuplikasiPostCommandHandler : IRequestHandler<RFJenisDuplikasiPostCommand, ServiceResponse<RFJenisDuplikasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisDuplikasi> _RFJenisDuplikasi;
        private readonly IMapper _mapper;

        public RFJenisDuplikasiPostCommandHandler(IGenericRepositoryAsync<RFJenisDuplikasi> RFJenisDuplikasi, IMapper mapper)
        {
            _RFJenisDuplikasi = RFJenisDuplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisDuplikasiResponseDto>> Handle(RFJenisDuplikasiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisDuplikasi = _mapper.Map<RFJenisDuplikasi>(request);

                var returnedRFJenisDuplikasi = await _RFJenisDuplikasi.AddAsync(RFJenisDuplikasi, callSave: false);

                // var response = _mapper.Map<RFJenisDuplikasiResponseDto>(returnedRFJenisDuplikasi);
                var response = _mapper.Map<RFJenisDuplikasiResponseDto>(returnedRFJenisDuplikasi);

                await _RFJenisDuplikasi.SaveChangeAsync();
                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisDuplikasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}