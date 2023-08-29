using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisKendaraanAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisKendaraanAgunans.Commands
{
    public class RFJenisKendaraanAgunanPostCommand : RFJenisKendaraanAgunanPostRequestDto, IRequest<ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {

    }
    public class PostRFJenisKendaraanAgunanCommandHandler : IRequestHandler<RFJenisKendaraanAgunanPostCommand, ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisKendaraanAgunan> _RFJenisKendaraanAgunan;
        private readonly IMapper _mapper;

        public PostRFJenisKendaraanAgunanCommandHandler(IGenericRepositoryAsync<RFJenisKendaraanAgunan> RFJenisKendaraanAgunan, IMapper mapper)
        {
            _RFJenisKendaraanAgunan = RFJenisKendaraanAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisKendaraanAgunanResponseDto>> Handle(RFJenisKendaraanAgunanPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFJenisKendaraanAgunan = _mapper.Map<RFJenisKendaraanAgunan>(request);

                var returnedRFJenisKendaraanAgunan = await _RFJenisKendaraanAgunan.AddAsync(RFJenisKendaraanAgunan, callSave: false);

                // var response = _mapper.Map<RFJenisKendaraanAgunanResponseDto>(returnedRFJenisKendaraanAgunan);
                var response = _mapper.Map<RFJenisKendaraanAgunanResponseDto>(returnedRFJenisKendaraanAgunan);

                await _RFJenisKendaraanAgunan.SaveChangeAsync();
                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}