using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKodeDinass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKodeDinass.Commands
{
    public class RFKodeDinasPostCommand : RFKodeDinasPostRequestDto, IRequest<ServiceResponse<RFKodeDinasResponseDto>>
    {

    }
    public class PostRFKodeDinasCommandHandler : IRequestHandler<RFKodeDinasPostCommand, ServiceResponse<RFKodeDinasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKodeDinas> _RFKodeDinas;
        private readonly IMapper _mapper;

        public PostRFKodeDinasCommandHandler(IGenericRepositoryAsync<RFKodeDinas> RFKodeDinas, IMapper mapper)
        {
            _RFKodeDinas = RFKodeDinas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKodeDinasResponseDto>> Handle(RFKodeDinasPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFKodeDinas = _mapper.Map<RFKodeDinas>(request);

                var returnedRfKodeDinas = await _RFKodeDinas.AddAsync(RFKodeDinas, callSave: false);

                // var response = _mapper.Map<RFKodeDinasResponseDto>(returnedRfStatusTarget);
                var response = _mapper.Map<RFKodeDinasResponseDto>(returnedRfKodeDinas);

                await _RFKodeDinas.SaveChangeAsync();
                return ServiceResponse<RFKodeDinasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKodeDinasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}