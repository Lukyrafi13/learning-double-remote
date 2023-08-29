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
    public class RFKepemilikanUsahaPostCommand : RFKepemilikanUsahaPostRequestDto, IRequest<ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {

    }
    public class RFKepemilikanUsahaPostCommandHandler : IRequestHandler<RFKepemilikanUsahaPostCommand, ServiceResponse<RFKepemilikanUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKepemilikanUsaha> _RFKepemilikanUsaha;
        private readonly IMapper _mapper;

        public RFKepemilikanUsahaPostCommandHandler(IGenericRepositoryAsync<RFKepemilikanUsaha> RFKepemilikanUsaha, IMapper mapper)
        {
            _RFKepemilikanUsaha = RFKepemilikanUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKepemilikanUsahaResponseDto>> Handle(RFKepemilikanUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFKepemilikanUsaha = _mapper.Map<RFKepemilikanUsaha>(request);

                var returnedRFKepemilikanUsaha = await _RFKepemilikanUsaha.AddAsync(RFKepemilikanUsaha, callSave: false);

                // var response = _mapper.Map<RFKepemilikanUsahaResponseDto>(returnedRFKepemilikanUsaha);
                var response = _mapper.Map<RFKepemilikanUsahaResponseDto>(returnedRFKepemilikanUsaha);

                await _RFKepemilikanUsaha.SaveChangeAsync();
                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKepemilikanUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}