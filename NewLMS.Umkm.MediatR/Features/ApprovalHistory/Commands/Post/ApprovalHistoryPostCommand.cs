using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.ApprovalHistorys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.ApprovalHistorys.Commands
{
    public class ApprovalHistoryPostCommand : ApprovalHistoryPostRequestDto, IRequest<ServiceResponse<ApprovalHistoryResponseDto>>
    {

    }
    public class PostApprovalHistoryCommandHandler : IRequestHandler<ApprovalHistoryPostCommand, ServiceResponse<ApprovalHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<ApprovalHistory> _ApprovalHistory;
        private readonly IMapper _mapper;

        public PostApprovalHistoryCommandHandler(IGenericRepositoryAsync<ApprovalHistory> ApprovalHistory, IMapper mapper)
        {
            _ApprovalHistory = ApprovalHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ApprovalHistoryResponseDto>> Handle(ApprovalHistoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var ApprovalHistory = _mapper.Map<ApprovalHistory>(request);

                var returnedApprovalHistory = await _ApprovalHistory.AddAsync(ApprovalHistory, callSave: false);

                // var response = _mapper.Map<ApprovalHistoryResponseDto>(returnedApprovalHistory);
                var response = _mapper.Map<ApprovalHistoryResponseDto>(returnedApprovalHistory);

                await _ApprovalHistory.SaveChangeAsync();
                return ServiceResponse<ApprovalHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprovalHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}