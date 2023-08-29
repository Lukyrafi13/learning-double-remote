using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Queries
{
    public class SIKPHistoryDetailGetQuery : SIKPHistoryDetailFindRequestDto, IRequest<ServiceResponse<SIKPHistoryDetailResponseDto>>
    {
    }

    public class SIKPHistoryDetailGetQueryHandler : IRequestHandler<SIKPHistoryDetailGetQuery, ServiceResponse<SIKPHistoryDetailResponseDto>>
    {
        private IGenericRepositoryAsync<SIKPHistoryDetail> _SIKPHistoryDetail;
        private readonly IMapper _mapper;

        public SIKPHistoryDetailGetQueryHandler(IGenericRepositoryAsync<SIKPHistoryDetail> SIKPHistoryDetail, IMapper mapper)
        {
            _SIKPHistoryDetail = SIKPHistoryDetail;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<SIKPHistoryDetailResponseDto>> Handle(SIKPHistoryDetailGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "SIKPHistory",
                };

                var data = await _SIKPHistoryDetail.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<SIKPHistoryDetailResponseDto>.Return404("Data SIKPHistoryDetail not found");
                var response = _mapper.Map<SIKPHistoryDetailResponseDto>(data);
                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SIKPHistoryDetailResponseDto>.ReturnException(ex);
            }
        }
    }
}