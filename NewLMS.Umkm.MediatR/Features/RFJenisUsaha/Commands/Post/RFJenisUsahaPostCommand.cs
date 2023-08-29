using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahas.Commands
{
    public class RFJenisUsahaPostCommand : RFJenisUsahaPostRequestDto, IRequest<ServiceResponse<RFJenisUsahaResponseDto>>
    {

    }
    public class PostRFJenisUsahaCommandHandler : IRequestHandler<RFJenisUsahaPostCommand, ServiceResponse<RFJenisUsahaResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public PostRFJenisUsahaCommandHandler(IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaResponseDto>> Handle(RFJenisUsahaPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisUsaha = _mapper.Map<RFJenisUsaha>(request);

                var returnedRFJenisUsaha = await _RFJenisUsaha.AddAsync(RFJenisUsaha, callSave: false);

                // var response = _mapper.Map<RFJenisUsahaResponseDto>(returnedRFJenisUsaha);
                var response = _mapper.Map<RFJenisUsahaResponseDto>(returnedRFJenisUsaha);

                await _RFJenisUsaha.SaveChangeAsync();
                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}