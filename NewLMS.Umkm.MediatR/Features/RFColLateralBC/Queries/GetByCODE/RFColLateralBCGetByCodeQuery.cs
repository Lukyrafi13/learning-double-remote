using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFColLateralBCs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFColLateralBCs.Queries
{
    public class RFColLateralBCsGetByCodeQuery : RFColLateralBCFindRequestDto, IRequest<ServiceResponse<RFColLateralBCResponseDto>>
    {
    }

    public class GetByCodeRFColLateralBCQueryHandler : IRequestHandler<RFColLateralBCsGetByCodeQuery, ServiceResponse<RFColLateralBCResponseDto>>
    {
        private IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public GetByCodeRFColLateralBCQueryHandler(IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC, IMapper mapper)
        {
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFColLateralBCResponseDto>> Handle(RFColLateralBCsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFColLateralBC.GetByIdAsync(request.ColCode, "ColCode");
                if (data == null)
                    return ServiceResponse<RFColLateralBCResponseDto>.Return404("Data RFColLateralBC not found");
                var response = _mapper.Map<RFColLateralBCResponseDto>(data);
                return ServiceResponse<RFColLateralBCResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFColLateralBCResponseDto>.ReturnException(ex);
            }
        }
    }
}