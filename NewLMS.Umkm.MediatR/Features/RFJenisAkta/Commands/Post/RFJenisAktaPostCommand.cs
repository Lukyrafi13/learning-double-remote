using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisAktas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisAktas.Commands
{
    public class RFJenisAktaPostCommand : RFJenisAktaPostRequestDto, IRequest<ServiceResponse<RFJenisAktaResponseDto>>
    {

    }
    public class RFJenisAktaPostCommandHandler : IRequestHandler<RFJenisAktaPostCommand, ServiceResponse<RFJenisAktaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisAkta> _RFJenisAkta;
        private readonly IMapper _mapper;

        public RFJenisAktaPostCommandHandler(IGenericRepositoryAsync<RFJenisAkta> RFJenisAkta, IMapper mapper)
        {
            _RFJenisAkta = RFJenisAkta;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisAktaResponseDto>> Handle(RFJenisAktaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisAkta = _mapper.Map<RFJenisAkta>(request);

                var returnedRFJenisAkta = await _RFJenisAkta.AddAsync(RFJenisAkta, callSave: false);

                // var response = _mapper.Map<RFJenisAktaResponseDto>(returnedRFJenisAkta);
                var response = _mapper.Map<RFJenisAktaResponseDto>(returnedRFJenisAkta);

                await _RFJenisAkta.SaveChangeAsync();
                return ServiceResponse<RFJenisAktaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisAktaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}