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
    public class RFBidangUsahaKURPutCommand : RFBidangUsahaKURPutRequestDto, IRequest<ServiceResponse<RFBidangUsahaKURResponseDto>>
    {
    }

    public class PutRFBidangUsahaKURCommandHandler : IRequestHandler<RFBidangUsahaKURPutCommand, ServiceResponse<RFBidangUsahaKURResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFBidangUsahaKUR> _RFBidangUsahaKUR;
        private readonly IMapper _mapper;

        public PutRFBidangUsahaKURCommandHandler(IGenericRepositoryAsync<RFBidangUsahaKUR> RFBidangUsahaKUR, IMapper mapper)
        {
            _RFBidangUsahaKUR = RFBidangUsahaKUR;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFBidangUsahaKURResponseDto>> Handle(RFBidangUsahaKURPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFBidangUsahaKUR = await _RFBidangUsahaKUR.GetByIdAsync(request.BTCode, "BTCode");
               
                existingRFBidangUsahaKUR.BTDesc = request.BTDesc;
                existingRFBidangUsahaKUR.CoreCode = request.CoreCode;
                existingRFBidangUsahaKUR.Active = request.Active;
                await _RFBidangUsahaKUR.UpdateAsync(existingRFBidangUsahaKUR);

                var response = _mapper.Map<RFBidangUsahaKURResponseDto>(existingRFBidangUsahaKUR);

                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBidangUsahaKURResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}