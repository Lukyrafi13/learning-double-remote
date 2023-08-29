using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands
{
    public class RFSCOTINGKATKEBUTUHANPostCommand : RFSCOTINGKATKEBUTUHANPostRequestDto, IRequest<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {

    }
    public class PostRFSCOTINGKATKEBUTUHANCommandHandler : IRequestHandler<RFSCOTINGKATKEBUTUHANPostCommand, ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> _RFSCOTINGKATKEBUTUHAN;
        private readonly IMapper _mapper;

        public PostRFSCOTINGKATKEBUTUHANCommandHandler(IGenericRepositoryAsync<RFSCOTINGKATKEBUTUHAN> RFSCOTINGKATKEBUTUHAN, IMapper mapper)
        {
            _RFSCOTINGKATKEBUTUHAN = RFSCOTINGKATKEBUTUHAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>> Handle(RFSCOTINGKATKEBUTUHANPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOTINGKATKEBUTUHAN = _mapper.Map<RFSCOTINGKATKEBUTUHAN>(request);

                var returnedRFSCOTINGKATKEBUTUHAN = await _RFSCOTINGKATKEBUTUHAN.AddAsync(RFSCOTINGKATKEBUTUHAN, callSave: false);

                // var response = _mapper.Map<RFSCOTINGKATKEBUTUHANResponseDto>(returnedRFSCOTINGKATKEBUTUHAN);
                var response = _mapper.Map<RFSCOTINGKATKEBUTUHANResponseDto>(returnedRFSCOTINGKATKEBUTUHAN);

                await _RFSCOTINGKATKEBUTUHAN.SaveChangeAsync();
                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}