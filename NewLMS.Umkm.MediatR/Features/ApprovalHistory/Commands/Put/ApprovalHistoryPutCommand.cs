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
    public class ApprovalHistoryPutCommand : ApprovalHistoryPutRequestDto, IRequest<ServiceResponse<ApprovalHistoryResponseDto>>
    {
    }

    public class PutApprovalHistoryCommandHandler : IRequestHandler<ApprovalHistoryPutCommand, ServiceResponse<ApprovalHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<ApprovalHistory> _ApprovalHistory;
        private readonly IMapper _mapper;

        public PutApprovalHistoryCommandHandler(IGenericRepositoryAsync<ApprovalHistory> ApprovalHistory, IMapper mapper)
        {
            _ApprovalHistory = ApprovalHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ApprovalHistoryResponseDto>> Handle(ApprovalHistoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingApprovalHistory = await _ApprovalHistory.GetByIdAsync(request.Id, "Id");
                existingApprovalHistory.ApprovalHistoryBy = request.ApprovalHistoryBy;
                existingApprovalHistory.TanggalMasuk = request.TanggalMasuk;
                existingApprovalHistory.ApprovalHistorySeq = request.ApprovalHistorySeq;
                existingApprovalHistory.ApprovalId = request.ApprovalId;

                await _ApprovalHistory.UpdateAsync(existingApprovalHistory);

                var response = _mapper.Map<ApprovalHistoryResponseDto>(existingApprovalHistory);

                return ServiceResponse<ApprovalHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ApprovalHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}