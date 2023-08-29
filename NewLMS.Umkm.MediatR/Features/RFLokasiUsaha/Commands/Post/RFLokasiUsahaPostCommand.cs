using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLokasiUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLokasiUsahas.Commands
{
    public class RFLokasiUsahaPostCommand : RFLokasiUsahaPostRequestDto, IRequest<ServiceResponse<RFLokasiUsahaResponseDto>>
    {

    }
    public class PostRFLokasiUsahaCommandHandler : IRequestHandler<RFLokasiUsahaPostCommand, ServiceResponse<RFLokasiUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFLokasiUsaha> _RFLokasiUsaha;
        private readonly IMapper _mapper;

        public PostRFLokasiUsahaCommandHandler(IGenericRepositoryAsync<RFLokasiUsaha> RFLokasiUsaha, IMapper mapper)
        {
            _RFLokasiUsaha = RFLokasiUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFLokasiUsahaResponseDto>> Handle(RFLokasiUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFLokasiUsaha = _mapper.Map<RFLokasiUsaha>(request);

                var returnedRFLokasiUsaha = await _RFLokasiUsaha.AddAsync(RFLokasiUsaha, callSave: false);

                // var response = _mapper.Map<RFLokasiUsahaResponseDto>(returnedRFLokasiUsaha);
                var response = _mapper.Map<RFLokasiUsahaResponseDto>(returnedRFLokasiUsaha);

                await _RFLokasiUsaha.SaveChangeAsync();
                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLokasiUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}