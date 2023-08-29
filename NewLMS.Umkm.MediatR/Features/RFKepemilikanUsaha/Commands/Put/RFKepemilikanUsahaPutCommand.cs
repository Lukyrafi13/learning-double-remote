using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanUsahas.Commands
{
    public class RFKepemilikanUsahaPutCommand : RFKepemilikanUsahaPutRequestDto, IRequest<ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {
    }

    public class RFKepemilikanUsahaPutCommandHandler : IRequestHandler<RFKepemilikanUsahaPutCommand, ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanUsaha> _RFKepemilikanUsaha;
        private readonly IMapper _mapper;

        public RFKepemilikanUsahaPutCommandHandler(IGenericRepositoryAsync<RFKepemilikanUsaha> RFKepemilikanUsaha, IMapper mapper)
        {
            _RFKepemilikanUsaha = RFKepemilikanUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKepemilikanUsahaResponseDto>> Handle(RFKepemilikanUsahaPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFKepemilikanUsaha = await _RFKepemilikanUsaha.GetByIdAsync(request.KepemilikanUsahaId, "KepemilikanUsahaId");
                
                existingRFKepemilikanUsaha.KepemilikanUsahaDesc = request.KepemilikanUsahaDesc;
                existingRFKepemilikanUsaha.CoreCode = request.CoreCode;
                existingRFKepemilikanUsaha.Active = request.Active;
                
                await _RFKepemilikanUsaha.UpdateAsync(existingRFKepemilikanUsaha);

                var response = _mapper.Map<RFKepemilikanUsahaResponseDto>(existingRFKepemilikanUsaha);

                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}