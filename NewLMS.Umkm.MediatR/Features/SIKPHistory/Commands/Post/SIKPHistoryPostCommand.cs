using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistorys.Commands
{
    public class SIKPHistoryPostCommand : SIKPHistoryPostRequestDto, IRequest<ServiceResponse<SIKPHistoryResponseDto>>
    {

    }
    public class SIKPHistoryPostCommandHandler : IRequestHandler<SIKPHistoryPostCommand, ServiceResponse<SIKPHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistory> _SIKPHistory;
        private readonly IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public SIKPHistoryPostCommandHandler(
            IGenericRepositoryAsync<SIKPHistory> SIKPHistory, 
            IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, 
            IMapper mapper)
        {
            _SIKPHistory = SIKPHistory;
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPHistoryResponseDto>> Handle(SIKPHistoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SIKPHistory = _mapper.Map<SIKPHistory>(request);

                var returnedSIKPHistory = await _SIKPHistory.AddAsync(SIKPHistory);

                // Add detail sikp history detail
                foreach (var detail in request.Details)
                {
                    var sikpDetail = _mapper.Map<SIKPHistoryDetail>(detail);

                    sikpDetail.SIKPHistoryId = returnedSIKPHistory.Id;

                    await _SIKPHistoryDetail.AddAsync(sikpDetail);
                }
                
                // var response = _mapper.Map<SIKPHistoryResponseDto>(returnedSIKPHistory);
                var response = _mapper.Map<SIKPHistoryResponseDto>(returnedSIKPHistory);

                return ServiceResponse<SIKPHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}