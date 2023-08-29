using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Commands
{
    public class RFJenisUsahaYangDihindariPostCommand : RFJenisUsahaYangDihindariPostRequestDto, IRequest<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {

    }
    public class PostRFJenisUsahaYangDihindariCommandHandler : IRequestHandler<RFJenisUsahaYangDihindariPostCommand, ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaYangDihindari> _RFJenisUsahaYangDihindari;
        private readonly IMapper _mapper;

        public PostRFJenisUsahaYangDihindariCommandHandler(IGenericRepositoryAsync<RFJenisUsahaYangDihindari> RFJenisUsahaYangDihindari, IMapper mapper)
        {
            _RFJenisUsahaYangDihindari = RFJenisUsahaYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>> Handle(RFJenisUsahaYangDihindariPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisUsahaYangDihindari = _mapper.Map<RFJenisUsahaYangDihindari>(request);

                var returnedRFJenisUsahaYangDihindari = await _RFJenisUsahaYangDihindari.AddAsync(RFJenisUsahaYangDihindari, callSave: false);

                // var response = _mapper.Map<RFJenisUsahaYangDihindariResponseDto>(returnedRFJenisUsahaYangDihindari);
                var response = _mapper.Map<RFJenisUsahaYangDihindariResponseDto>(returnedRFJenisUsahaYangDihindari);

                await _RFJenisUsahaYangDihindari.SaveChangeAsync();
                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}