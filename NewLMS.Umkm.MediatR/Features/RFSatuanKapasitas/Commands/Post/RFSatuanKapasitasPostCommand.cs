using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Commands
{
    public class RFSatuanKapasitasPostCommand : RFSatuanKapasitasPostRequestDto, IRequest<ServiceResponse<RFSatuanKapasitasResponseDto>>
    {

    }
    public class PostRFSatuanKapasitasCommandHandler : IRequestHandler<RFSatuanKapasitasPostCommand, ServiceResponse<RFSatuanKapasitasResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSatuanKapasitas> _RFSatuanKapasitas;
        private readonly IMapper _mapper;

        public PostRFSatuanKapasitasCommandHandler(IGenericRepositoryAsync<RFSatuanKapasitas> RFSatuanKapasitas, IMapper mapper)
        {
            _RFSatuanKapasitas = RFSatuanKapasitas;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSatuanKapasitasResponseDto>> Handle(RFSatuanKapasitasPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSatuanKapasitas = _mapper.Map<RFSatuanKapasitas>(request);

                var returnedRFSatuanKapasitas = await _RFSatuanKapasitas.AddAsync(RFSatuanKapasitas, callSave: false);

                // var response = _mapper.Map<RFSatuanKapasitasResponseDto>(returnedRFSatuanKapasitas);
                var response = _mapper.Map<RFSatuanKapasitasResponseDto>(returnedRFSatuanKapasitas);

                await _RFSatuanKapasitas.SaveChangeAsync();
                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSatuanKapasitasResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}