using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBentukLahans.Commands
{
    public class RFBentukLahanPostCommand : RFBentukLahanPostRequestDto, IRequest<ServiceResponse<RFBentukLahanResponseDto>>
    {

    }
    public class PostRFBentukLahanCommandHandler : IRequestHandler<RFBentukLahanPostCommand, ServiceResponse<RFBentukLahanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBentukLahan> _RFBentukLahan;
        private readonly IMapper _mapper;

        public PostRFBentukLahanCommandHandler(IGenericRepositoryAsync<RFBentukLahan> RFBentukLahan, IMapper mapper)
        {
            _RFBentukLahan = RFBentukLahan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBentukLahanResponseDto>> Handle(RFBentukLahanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBentukLahan = _mapper.Map<RFBentukLahan>(request);

                var returnedRFBentukLahan = await _RFBentukLahan.AddAsync(RFBentukLahan, callSave: false);

                // var response = _mapper.Map<RFBentukLahanResponseDto>(returnedRFBentukLahan);
                var response = _mapper.Map<RFBentukLahanResponseDto>(returnedRFBentukLahan);

                await _RFBentukLahan.SaveChangeAsync();
                return ServiceResponse<RFBentukLahanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBentukLahanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}