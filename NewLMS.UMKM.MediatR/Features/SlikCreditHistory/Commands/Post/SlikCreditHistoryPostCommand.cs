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
    public class SlikCreditHistoryPostCommand : SlikCreditHistoryPostRequestDto, IRequest<ServiceResponse<SlikCreditHistoryResponseDto>>
    {

    }
    public class SlikCreditHistoryPostCommandHandler : IRequestHandler<SlikCreditHistoryPostCommand, ServiceResponse<SlikCreditHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SlikCreditHistory> _SlikCreditHistory;
        private readonly IMapper _mapper;

        public SlikCreditHistoryPostCommandHandler(IGenericRepositoryAsync<SlikCreditHistory> SlikCreditHistory, IMapper mapper)
        {
            _SlikCreditHistory = SlikCreditHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SlikCreditHistoryResponseDto>> Handle(SlikCreditHistoryPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var SlikCreditHistory = _mapper.Map<SlikCreditHistory>(request);

                var returnedSlikCreditHistory = await _SlikCreditHistory.AddAsync(SlikCreditHistory, callSave: false);

                // var response = _mapper.Map<SlikCreditHistoryResponseDto>(returnedSlikCreditHistory);
                var response = _mapper.Map<SlikCreditHistoryResponseDto>(returnedSlikCreditHistory);

                await _SlikCreditHistory.SaveChangeAsync();
                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SlikCreditHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}