using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Commands
{
    public class RFKelompokUsahaPostCommand : RFKelompokUsahaPostRequestDto, IRequest<ServiceResponse<RFKelompokUsahaResponseDto>>
    {

    }
    public class PostRFKelompokUsahaCommandHandler : IRequestHandler<RFKelompokUsahaPostCommand, ServiceResponse<RFKelompokUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFKelompokUsaha> _RFKelompokUsaha;
        private readonly IMapper _mapper;

        public PostRFKelompokUsahaCommandHandler(IGenericRepositoryAsync<RFKelompokUsaha> RFKelompokUsaha, IMapper mapper)
        {
            _RFKelompokUsaha = RFKelompokUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFKelompokUsahaResponseDto>> Handle(RFKelompokUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFKelompokUsaha = _mapper.Map<RFKelompokUsaha>(request);

                var returnedRFKelompokUsaha = await _RFKelompokUsaha.AddAsync(RFKelompokUsaha, callSave: false);

                // var response = _mapper.Map<RFKelompokUsahaResponseDto>(returnedRFKelompokUsaha);
                var response = _mapper.Map<RFKelompokUsahaResponseDto>(returnedRFKelompokUsaha);

                await _RFKelompokUsaha.SaveChangeAsync();
                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFKelompokUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}