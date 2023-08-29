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
    public class RFSCOHUBUNGANPERBANKANPostCommand : RFSCOHUBUNGANPERBANKANPostRequestDto, IRequest<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {

    }
    public class PostRFSCOHUBUNGANPERBANKANCommandHandler : IRequestHandler<RFSCOHUBUNGANPERBANKANPostCommand, ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> _RFSCOHUBUNGANPERBANKAN;
        private readonly IMapper _mapper;

        public PostRFSCOHUBUNGANPERBANKANCommandHandler(IGenericRepositoryAsync<RFSCOHUBUNGANPERBANKAN> RFSCOHUBUNGANPERBANKAN, IMapper mapper)
        {
            _RFSCOHUBUNGANPERBANKAN = RFSCOHUBUNGANPERBANKAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>> Handle(RFSCOHUBUNGANPERBANKANPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOHUBUNGANPERBANKAN = _mapper.Map<RFSCOHUBUNGANPERBANKAN>(request);

                var returnedRFSCOHUBUNGANPERBANKAN = await _RFSCOHUBUNGANPERBANKAN.AddAsync(RFSCOHUBUNGANPERBANKAN, callSave: false);

                // var response = _mapper.Map<RFSCOHUBUNGANPERBANKANResponseDto>(returnedRFSCOHUBUNGANPERBANKAN);
                var response = _mapper.Map<RFSCOHUBUNGANPERBANKANResponseDto>(returnedRFSCOHUBUNGANPERBANKAN);

                await _RFSCOHUBUNGANPERBANKAN.SaveChangeAsync();
                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}