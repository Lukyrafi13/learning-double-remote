using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBidangUsahaKURs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBidangUsahaKURs.Commands
{
    public class RFBidangUsahaKURPostCommand : RFBidangUsahaKURPostRequestDto, IRequest<ServiceResponse<RFBidangUsahaKURResponseDto>>
    {

    }
    public class RFBidangUsahaKURPostCommandHandler : IRequestHandler<RFBidangUsahaKURPostCommand, ServiceResponse<RFBidangUsahaKURResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBidangUsahaKUR> _RFBidangUsahaKUR;
        private readonly IMapper _mapper;

        public RFBidangUsahaKURPostCommandHandler(IGenericRepositoryAsync<RFBidangUsahaKUR> RFBidangUsahaKUR, IMapper mapper)
        {
            _RFBidangUsahaKUR = RFBidangUsahaKUR;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBidangUsahaKURResponseDto>> Handle(RFBidangUsahaKURPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFBidangUsahaKUR = _mapper.Map<RFBidangUsahaKUR>(request);

                var returnedRFBidangUsahaKUR = await _RFBidangUsahaKUR.AddAsync(RFBidangUsahaKUR, callSave: false);

                // var response = _mapper.Map<RFBidangUsahaKURResponseDto>(returnedRFBidangUsahaKUR);
                var response = _mapper.Map<RFBidangUsahaKURResponseDto>(returnedRFBidangUsahaKUR);

                await _RFBidangUsahaKUR.SaveChangeAsync();
                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}