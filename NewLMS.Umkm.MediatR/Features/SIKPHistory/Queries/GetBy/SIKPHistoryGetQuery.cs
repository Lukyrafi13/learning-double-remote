using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistorys.Queries
{
    public class SIKPHistoryGetQuery : SIKPHistoryFindRequestDto, IRequest<ServiceResponse<SIKPHistoryResponseDto>>
    {
    }

    public class SIKPHistoryGetQueryHandler : IRequestHandler<SIKPHistoryGetQuery, ServiceResponse<SIKPHistoryResponseDto>>
    {
        private IGenericRepositoryAsync<SIKPHistory> _SIKPHistory;
        private IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public SIKPHistoryGetQueryHandler(
            IGenericRepositoryAsync<SIKPHistory> SIKPHistory,
            IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail,
            IMapper mapper)
        {
            _SIKPHistory = SIKPHistory;
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SIKPHistoryResponseDto>> Handle(SIKPHistoryGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "SubSubSektorEkonomiLBU"
                };

                var data = await _SIKPHistory.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SIKPHistoryResponseDto>.Return404("Data SIKPHistory not found");
                var firstDetail = (await _SIKPHistoryDetail.GetListByPredicate(x=> x.SIKPHistoryId == data.Id))[0];
                
                var response = _mapper.Map<SIKPHistoryResponseDto>(data);
                
                response.AkadDiizinkan = firstDetail.MaxJumlahAkad - firstDetail.JumlahAkad;
                response.RateAkad = firstDetail.RateAkad;
                response.LimitAktif = firstDetail.LimitAktif;
                
                return ServiceResponse<SIKPHistoryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryResponseDto>.ReturnException(ex);
            }
        }
    }
}