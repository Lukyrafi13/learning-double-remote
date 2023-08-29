using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCSBPDetails;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFCSBPDetails.Queries
{
    public class RFCSBPDetailGetQuery : RFCSBPDetailFindRequestDto, IRequest<ServiceResponse<RFCSBPDetailResponseDto>>
    {
    }

    public class RFCSBPDetailGetQueryHandler : IRequestHandler<RFCSBPDetailGetQuery, ServiceResponse<RFCSBPDetailResponseDto>>
    {
        private IGenericRepositoryAsync<RFCSBPDetail> _RFCSBPDetail;
        private readonly IMapper _mapper;

        public RFCSBPDetailGetQueryHandler(IGenericRepositoryAsync<RFCSBPDetail> RFCSBPDetail, IMapper mapper)
        {
            _RFCSBPDetail = RFCSBPDetail;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFCSBPDetailResponseDto>> Handle(RFCSBPDetailGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFCSBPDetail.GetByIdAsync(request.CSBPDetailID, "CSBPDetailID");
                if (data == null)
                    return ServiceResponse<RFCSBPDetailResponseDto>.Return404("Data RFCSBPDetail not found");
                var response = _mapper.Map<RFCSBPDetailResponseDto>(data);
                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCSBPDetailResponseDto>.ReturnException(ex);
            }
        }
    }
}