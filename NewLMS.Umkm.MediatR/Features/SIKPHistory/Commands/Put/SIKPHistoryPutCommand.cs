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
    public class SIKPHistoryPutCommand : SIKPHistoryPutRequestDto, IRequest<ServiceResponse<SIKPHistoryResponseDto>>
    {
    }

    public class PutSIKPHistoryCommandHandler : IRequestHandler<SIKPHistoryPutCommand, ServiceResponse<SIKPHistoryResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SIKPHistory> _SIKPHistory;
        private readonly IMapper _mapper;

        public PutSIKPHistoryCommandHandler(IGenericRepositoryAsync<SIKPHistory> SIKPHistory, IMapper mapper)
        {
            _SIKPHistory = SIKPHistory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SIKPHistoryResponseDto>> Handle(SIKPHistoryPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSIKPHistory = await _SIKPHistory.GetByIdAsync(request.Id, "Id");
                
                existingSIKPHistory.NoKTP = request.NoKTP;
                existingSIKPHistory.KodeBank = request.KodeBank;
                existingSIKPHistory.SisaHariBook = request.SisaHariBook;
                existingSIKPHistory.Plafond = request.Plafond;
                existingSIKPHistory.RfSectorLBU3Code = request.RfSectorLBU3Code;

                await _SIKPHistory.UpdateAsync(existingSIKPHistory);

                var response = _mapper.Map<SIKPHistoryResponseDto>(existingSIKPHistory);

                return ServiceResponse<SIKPHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}