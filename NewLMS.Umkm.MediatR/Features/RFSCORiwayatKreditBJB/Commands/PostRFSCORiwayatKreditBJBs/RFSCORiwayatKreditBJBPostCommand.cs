using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCORiwayatKreditBJBs.Commands
{
    public class RFSCORiwayatKreditBJBPostCommand : RFSCORiwayatKreditBJBPostRequestDto, IRequest<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {

    }
    public class PostRFSCORiwayatKreditBJBCommandHandler : IRequestHandler<RFSCORiwayatKreditBJBPostCommand, ServiceResponse<RFSCORiwayatKreditBJBResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCORiwayatKreditBJB> _RFSCORiwayatKreditBJB;
        private readonly IMapper _mapper;

        public PostRFSCORiwayatKreditBJBCommandHandler(IGenericRepositoryAsync<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJB, IMapper mapper)
        {
            _RFSCORiwayatKreditBJB = RFSCORiwayatKreditBJB;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCORiwayatKreditBJBResponseDto>> Handle(RFSCORiwayatKreditBJBPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCORiwayatKreditBJB = _mapper.Map<RFSCORiwayatKreditBJB>(request);

                var returnedRFSCORiwayatKreditBJB = await _RFSCORiwayatKreditBJB.AddAsync(RFSCORiwayatKreditBJB, callSave: false);

                // var response = _mapper.Map<RFSCORiwayatKreditBJBResponseDto>(returnedRFSCORiwayatKreditBJB);
                var response = _mapper.Map<RFSCORiwayatKreditBJBResponseDto>(returnedRFSCORiwayatKreditBJB);

                await _RFSCORiwayatKreditBJB.SaveChangeAsync();
                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCORiwayatKreditBJBResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}