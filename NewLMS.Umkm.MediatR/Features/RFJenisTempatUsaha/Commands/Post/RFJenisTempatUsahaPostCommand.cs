using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisTempatUsahas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisTempatUsahas.Commands
{
    public class RFJenisTempatUsahaPostCommand : RFJenisTempatUsahaPostRequestDto, IRequest<ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {

    }
    public class PostRFJenisTempatUsahaCommandHandler : IRequestHandler<RFJenisTempatUsahaPostCommand, ServiceResponse<RFJenisTempatUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisTempatUsaha> _RFJenisTempatUsaha;
        private readonly IMapper _mapper;

        public PostRFJenisTempatUsahaCommandHandler(IGenericRepositoryAsync<RFJenisTempatUsaha> RFJenisTempatUsaha, IMapper mapper)
        {
            _RFJenisTempatUsaha = RFJenisTempatUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisTempatUsahaResponseDto>> Handle(RFJenisTempatUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisTempatUsaha = _mapper.Map<RFJenisTempatUsaha>(request);

                var returnedRFJenisTempatUsaha = await _RFJenisTempatUsaha.AddAsync(RFJenisTempatUsaha, callSave: false);

                // var response = _mapper.Map<RFJenisTempatUsahaResponseDto>(returnedRFJenisTempatUsaha);
                var response = _mapper.Map<RFJenisTempatUsahaResponseDto>(returnedRFJenisTempatUsaha);

                await _RFJenisTempatUsaha.SaveChangeAsync();
                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisTempatUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}