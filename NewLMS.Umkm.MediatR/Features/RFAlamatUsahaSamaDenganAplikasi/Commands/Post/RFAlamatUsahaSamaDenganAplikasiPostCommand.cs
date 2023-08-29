using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands
{
    public class RFAlamatUsahaSamaDenganAplikasiPostCommand : RFAlamatUsahaSamaDenganAplikasiPostRequestDto, IRequest<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {

    }
    public class PostRFAlamatUsahaSamaDenganAplikasiCommandHandler : IRequestHandler<RFAlamatUsahaSamaDenganAplikasiPostCommand, ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> _RFAlamatUsahaSamaDenganAplikasi;
        private readonly IMapper _mapper;

        public PostRFAlamatUsahaSamaDenganAplikasiCommandHandler(IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> RFAlamatUsahaSamaDenganAplikasi, IMapper mapper)
        {
            _RFAlamatUsahaSamaDenganAplikasi = RFAlamatUsahaSamaDenganAplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>> Handle(RFAlamatUsahaSamaDenganAplikasiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFAlamatUsahaSamaDenganAplikasi = _mapper.Map<AlamatUsahaSamaDenganAplikasi>(request);

                var returnedRFAlamatUsahaSamaDenganAplikasi = await _RFAlamatUsahaSamaDenganAplikasi.AddAsync(RFAlamatUsahaSamaDenganAplikasi, callSave: false);

                // var response = _mapper.Map<RFAlamatUsahaSamaDenganAplikasiResponseDto>(returnedRFAlamatUsahaSamaDenganAplikasi);
                var response = _mapper.Map<RFAlamatUsahaSamaDenganAplikasiResponseDto>(returnedRFAlamatUsahaSamaDenganAplikasi);

                await _RFAlamatUsahaSamaDenganAplikasi.SaveChangeAsync();
                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}