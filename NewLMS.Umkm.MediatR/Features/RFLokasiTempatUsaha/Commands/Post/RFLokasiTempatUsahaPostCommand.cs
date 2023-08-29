using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLokasiTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiTempatUsahas.Commands
{
    public class RFLokasiTempatUsahaPostCommand : RFLokasiTempatUsahaPostRequestDto, IRequest<ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {

    }
    public class PostRFLokasiTempatUsahaCommandHandler : IRequestHandler<RFLokasiTempatUsahaPostCommand, ServiceResponse<RFLokasiTempatUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiTempatUsaha> _RFLokasiTempatUsaha;
        private readonly IMapper _mapper;

        public PostRFLokasiTempatUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiTempatUsaha> RFLokasiTempatUsaha, IMapper mapper)
        {
            _RFLokasiTempatUsaha = RFLokasiTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLokasiTempatUsahaResponseDto>> Handle(RFLokasiTempatUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFLokasiTempatUsaha = _mapper.Map<RFLokasiTempatUsaha>(request);

                var returnedRFLokasiTempatUsaha = await _RFLokasiTempatUsaha.AddAsync(RFLokasiTempatUsaha, callSave: false);

                // var response = _mapper.Map<RFLokasiTempatUsahaResponseDto>(returnedRFLokasiTempatUsaha);
                var response = _mapper.Map<RFLokasiTempatUsahaResponseDto>(returnedRFLokasiTempatUsaha);

                await _RFLokasiTempatUsaha.SaveChangeAsync();
                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiTempatUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}