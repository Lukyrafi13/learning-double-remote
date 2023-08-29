using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Data.Dto.RFMARITALs;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Commands
{
    public class RFMARITALSPostCommand : RFMARITALPostRequestDto, IRequest<ServiceResponse<RFMARITALResponseDto>>
    {

    }
    public class PostRFMARITALCommandHandler : IRequestHandler<RFMARITALSPostCommand, ServiceResponse<RFMARITALResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IMapper _mapper;

        public PostRFMARITALCommandHandler(IGenericRepositoryAsync<RFMARITAL> RFMARITAL, IMapper mapper)
        {
            _RFMARITAL = RFMARITAL;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMARITALResponseDto>> Handle(RFMARITALSPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var RFMARITAL = _mapper.Map<RFMARITAL>(request);

                var returnedRFMARITAL = await _RFMARITAL.AddAsync(RFMARITAL, callSave: false);

                // var response = _mapper.Map<RFProductResponseDto>(returnedRfProduct);
                var response = _mapper.Map<RFMARITALResponseDto>(returnedRFMARITAL);

                await _RFMARITAL.SaveChangeAsync();
                return ServiceResponse<RFMARITALResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMARITALResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}