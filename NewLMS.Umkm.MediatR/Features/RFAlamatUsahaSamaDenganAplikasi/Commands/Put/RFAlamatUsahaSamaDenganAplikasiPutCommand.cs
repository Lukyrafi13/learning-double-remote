using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands
{
    public class RFAlamatUsahaSamaDenganAplikasiPutCommand : RFAlamatUsahaSamaDenganAplikasiPutRequestDto, IRequest<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {
    }

    public class PutRFAlamatUsahaSamaDenganAplikasiCommandHandler : IRequestHandler<RFAlamatUsahaSamaDenganAplikasiPutCommand, ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> _RFAlamatUsahaSamaDenganAplikasi;
        private readonly IMapper _mapper;

        public PutRFAlamatUsahaSamaDenganAplikasiCommandHandler(IGenericRepositoryAsync<AlamatUsahaSamaDenganAplikasi> RFAlamatUsahaSamaDenganAplikasi, IMapper mapper)
        {
            _RFAlamatUsahaSamaDenganAplikasi = RFAlamatUsahaSamaDenganAplikasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>> Handle(RFAlamatUsahaSamaDenganAplikasiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFAlamatUsahaSamaDenganAplikasi = await _RFAlamatUsahaSamaDenganAplikasi.GetByIdAsync(request.StatusAlamat_Code, "StatusAlamat_Code");
                existingRFAlamatUsahaSamaDenganAplikasi.StatusAlamat_Code = request.StatusAlamat_Code;
                existingRFAlamatUsahaSamaDenganAplikasi.StatusAlamat_Desc = request.StatusAlamat_Desc;


                await _RFAlamatUsahaSamaDenganAplikasi.UpdateAsync(existingRFAlamatUsahaSamaDenganAplikasi);

                var response = _mapper.Map<RFAlamatUsahaSamaDenganAplikasiResponseDto>(existingRFAlamatUsahaSamaDenganAplikasi);

                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}