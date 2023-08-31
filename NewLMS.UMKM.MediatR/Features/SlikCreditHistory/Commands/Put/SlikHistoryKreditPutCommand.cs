using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Commands
{
    public class SlikCreditHistoryPutCommand : SlikCreditHistoryPutRequestDto, IRequest<ServiceResponse<SlikCreditHistoryResponseDto>>
    {
    }

    public class PutSlikCreditHistoryCommandHandler : IRequestHandler<SlikCreditHistoryPutCommand, ServiceResponse<SlikCreditHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikCreditHistory> _SlikCreditHistory;
        private readonly IMapper _mapper;

        public PutSlikCreditHistoryCommandHandler(IGenericRepositoryAsync<SlikCreditHistory> SlikCreditHistory, IMapper mapper)
        {
            _SlikCreditHistory = SlikCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikCreditHistoryResponseDto>> Handle(SlikCreditHistoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSlikCreditHistory = await _SlikCreditHistory.GetByIdAsync(request.Id, "Id");
                
                existingSlikCreditHistory = _mapper.Map<SlikCreditHistoryPutRequestDto, SlikCreditHistory>(request, existingSlikCreditHistory);

                await _SlikCreditHistory.UpdateAsync(existingSlikCreditHistory);

                var response = _mapper.Map<SlikCreditHistoryResponseDto>(existingSlikCreditHistory);

                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}