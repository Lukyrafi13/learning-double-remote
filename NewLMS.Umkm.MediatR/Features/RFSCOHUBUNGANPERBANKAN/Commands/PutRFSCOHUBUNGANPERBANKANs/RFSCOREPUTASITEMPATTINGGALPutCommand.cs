using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOHUBUNGANPERBANKANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Commands
{
    public class RFSCOHUBUNGANPERBANKANPutCommand : RFSCOHUBUNGANPERBANKANPutRequestDto, IRequest<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {
    }

    public class PutRFSCOHUBUNGANPERBANKANCommandHandler : IRequestHandler<RFSCOHUBUNGANPERBANKANPutCommand, ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> _RFSCOHUBUNGANPERBANKAN;
        private readonly IMapper _mapper;

        public PutRFSCOHUBUNGANPERBANKANCommandHandler(IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN, IMapper mapper){
            _RFSCOHUBUNGANPERBANKAN = RFSCOHUBUNGANPERBANKAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>> Handle(RFSCOHUBUNGANPERBANKANPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSCOHUBUNGANPERBANKAN = await _RFSCOHUBUNGANPERBANKAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                existingRFSCOHUBUNGANPERBANKAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOHUBUNGANPERBANKAN.SCO_DESC = request.SCO_DESC;
                existingRFSCOHUBUNGANPERBANKAN.SCO_CODE = request.SCO_CODE;
                existingRFSCOHUBUNGANPERBANKAN.ACTIVE = request.ACTIVE;
                
                await _RFSCOHUBUNGANPERBANKAN.UpdateAsync(existingRFSCOHUBUNGANPERBANKAN);

                var response = _mapper.Map<RFSCOHUBUNGANPERBANKANResponseDto>(existingRFSCOHUBUNGANPERBANKAN);

                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}