using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKodeDinass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKodeDinass.Commands
{
    public class RFKodeDinasPutCommand : RFKodeDinasPutRequestDto, IRequest<ServiceResponse<RFKodeDinasResponseDto>>
    {
    }

    public class PutRFKodeDinasCommandHandler : IRequestHandler<RFKodeDinasPutCommand, ServiceResponse<RFKodeDinasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKodeDinas> _RFKodeDinas;
        private readonly IMapper _mapper;

        public PutRFKodeDinasCommandHandler(IGenericRepositoryAsync<RFKodeDinas> RFKodeDinas, IMapper mapper){
            _RFKodeDinas = RFKodeDinas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKodeDinasResponseDto>> Handle(RFKodeDinasPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFKodeDinas = await _RFKodeDinas.GetByIdAsync(request.KodeDinas, "KodeDinas");
                existingRFKodeDinas.KodeDinas = request.KodeDinas;
                existingRFKodeDinas.Mitra = request.Mitra;
                existingRFKodeDinas.SektorEkonomi = request.SektorEkonomi;
                existingRFKodeDinas.Budidaya = request.Budidaya;
                existingRFKodeDinas.Active = request.Active;
                
                await _RFKodeDinas.UpdateAsync(existingRFKodeDinas);

                var response = _mapper.Map<RFKodeDinasResponseDto>(existingRFKodeDinas);

                return ServiceResponse<RFKodeDinasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKodeDinasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}