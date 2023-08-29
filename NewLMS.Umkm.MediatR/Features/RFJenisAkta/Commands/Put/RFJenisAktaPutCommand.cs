using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisAktas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisAktas.Commands
{
    public class RFJenisAktaPutCommand : RFJenisAktaPutRequestDto, IRequest<ServiceResponse<RFJenisAktaResponseDto>>
    {
    }

    public class PutRFJenisAktaCommandHandler : IRequestHandler<RFJenisAktaPutCommand, ServiceResponse<RFJenisAktaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAkta> _RFJenisAkta;
        private readonly IMapper _mapper;

        public PutRFJenisAktaCommandHandler(IGenericRepositoryAsync<RFJenisAkta> RFJenisAkta, IMapper mapper)
        {
            _RFJenisAkta = RFJenisAkta;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisAktaResponseDto>> Handle(RFJenisAktaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisAkta = await _RFJenisAkta.GetByIdAsync(request.AktaCode, "AktaCode");
                
                existingRFJenisAkta.AktaCode = request.AktaCode;
                existingRFJenisAkta.AktaDesc = request.AktaDesc;
                existingRFJenisAkta.CoreCode = request.CoreCode;
                
                await _RFJenisAkta.UpdateAsync(existingRFJenisAkta);

                var response = _mapper.Map<RFJenisAktaResponseDto>(existingRFJenisAkta);

                return ServiceResponse<RFJenisAktaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAktaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}