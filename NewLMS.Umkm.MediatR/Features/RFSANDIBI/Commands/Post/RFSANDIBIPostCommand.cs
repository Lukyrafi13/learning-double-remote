using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Commands
{
    public class RFSANDIBIPostCommand : RFSANDIBIPostRequestDto, IRequest<ServiceResponse<RFSANDIBIResponseDto>>
    {

    }
    public class PostRFSANDIBICommandHandler : IRequestHandler<RFSANDIBIPostCommand, ServiceResponse<RFSANDIBIResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSANDIBI> _RFSANDIBI;
        private readonly IMapper _mapper;

        public PostRFSANDIBICommandHandler(IGenericRepositoryAsync<RFSANDIBI> RFSANDIBI, IMapper mapper)
        {
            _RFSANDIBI = RFSANDIBI;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSANDIBIResponseDto>> Handle(RFSANDIBIPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSANDIBI = _mapper.Map<RFSANDIBI>(request);

                var returnedRFSANDIBI = await _RFSANDIBI.AddAsync(RFSANDIBI, callSave: false);

                // var response = _mapper.Map<RFSANDIBIResponseDto>(returnedRFSANDIBI);
                var response = _mapper.Map<RFSANDIBIResponseDto>(returnedRFSANDIBI);

                await _RFSANDIBI.SaveChangeAsync();
                return ServiceResponse<RFSANDIBIResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSANDIBIResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}