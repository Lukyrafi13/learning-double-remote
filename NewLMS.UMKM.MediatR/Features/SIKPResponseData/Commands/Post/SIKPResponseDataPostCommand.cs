using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Commands
{
    public class SIKPResponseDataPostCommand : SIKPResponseDataPostRequestDto, IRequest<ServiceResponse<SIKPResponseDataResponseDto>>
    {

    }
    public class SIKPResponseDataPostCommandHandler : IRequestHandler<SIKPResponseDataPostCommand, ServiceResponse<SIKPResponseDataResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IMapper _mapper;

        public SIKPResponseDataPostCommandHandler(IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData, IMapper mapper)
        {
            _SIKPResponseData = SIKPResponseData;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPResponseDataResponseDto>> Handle(SIKPResponseDataPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SIKPResponseData = _mapper.Map<SIKPResponseData>(request);

                var returnedSIKPResponseData = await _SIKPResponseData.AddAsync(SIKPResponseData, callSave: false);

                // var response = _mapper.Map<SIKPResponseDataResponseDto>(returnedSIKPResponseData);
                var response = _mapper.Map<SIKPResponseDataResponseDto>(returnedSIKPResponseData);

                await _SIKPResponseData.SaveChangeAsync();
                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPResponseDataResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}