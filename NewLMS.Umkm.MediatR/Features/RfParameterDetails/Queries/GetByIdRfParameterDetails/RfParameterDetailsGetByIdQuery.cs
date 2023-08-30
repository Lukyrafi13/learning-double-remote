using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RfParameterDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfParameterDetails.Queries.GetByIdRfParameterDetails
{
    public class RfParameterDetailsGetByIdQuery : IRequest<ServiceResponse<RfParameterDetailResponse>>
    {
        public int ParameterDetailId { get; set; }
    }

    public class GetByIdRfParameterDetailQueryHandler : IRequestHandler<RfParameterDetailsGetByIdQuery, ServiceResponse<RfParameterDetailResponse>>
    {
        private IGenericRepositoryAsync<RfParameterDetail> _rfParameterDetail;
        private readonly IMapper _mapper;

        public GetByIdRfParameterDetailQueryHandler(IGenericRepositoryAsync<RfParameterDetail> rfParameterDetail, IMapper mapper)
        {
            _rfParameterDetail = rfParameterDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfParameterDetailResponse>> Handle(RfParameterDetailsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] { "RfParameter" };
                var data = await _rfParameterDetail.GetByIdAsync(request.ParameterDetailId, "ParameterDetailId", includes);
                if (data == null)
                    return ServiceResponse<RfParameterDetailResponse>.Return404("Data RfParameterDetail not found");
                var dataVm = _mapper.Map<RfParameterDetailResponse>(data);
                return ServiceResponse<RfParameterDetailResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {

                return ServiceResponse<RfParameterDetailResponse>.ReturnException(ex);
            }
           
        }
    }
}
