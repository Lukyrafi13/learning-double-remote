using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SIKPHistoryDetails;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SIKPHistoryDetails.Commands
{
    public class SIKPHistoryDetailPostCommand : SIKPHistoryDetailPostRequestDto, IRequest<ServiceResponse<SIKPHistoryDetailResponseDto>>
    {

    }
    public class SIKPHistoryDetailPostCommandHandler : IRequestHandler<SIKPHistoryDetailPostCommand, ServiceResponse<SIKPHistoryDetailResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public SIKPHistoryDetailPostCommandHandler(IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, IMapper mapper)
        {
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPHistoryDetailResponseDto>> Handle(SIKPHistoryDetailPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SIKPHistoryDetail = _mapper.Map<SIKPHistoryDetail>(request);

                var returnedSIKPHistoryDetail = await _SIKPHistoryDetail.AddAsync(SIKPHistoryDetail, callSave: false);

                // var response = _mapper.Map<SIKPHistoryDetailResponseDto>(returnedSIKPHistoryDetail);
                var response = _mapper.Map<SIKPHistoryDetailResponseDto>(returnedSIKPHistoryDetail);

                await _SIKPHistoryDetail.SaveChangeAsync();
                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}