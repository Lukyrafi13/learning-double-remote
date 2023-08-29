using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RFMARITALs;
using NewLMS.UMKM.Repository.GenericRepository;
using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.MediatR.Features.RFMARITALs.Queries
{
    public class GetByIdRFMARITALQuery : RFMARITALFindRequestDto, IRequest<ServiceResponse<RFMARITALResponseDto>>
    {
    }

    public class GetByIdRFMARITALQueryHandler : IRequestHandler<GetByIdRFMARITALQuery, ServiceResponse<RFMARITALResponseDto>>
    {
        private IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IMapper _mapper;

        public GetByIdRFMARITALQueryHandler(IGenericRepositoryAsync<RFMARITAL> RFMARITAL, IMapper mapper)
        {
            _RFMARITAL = RFMARITAL;
            _mapper = mapper;
        }
        public async
        Task<ServiceResponse<RFMARITALResponseDto>> Handle(GetByIdRFMARITALQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFMARITAL.GetByIdAsync(request.MR_CODE, "MR_CODE");
            if (data == null)
                return ServiceResponse<RFMARITALResponseDto>.Return404("Data RFMARITAL not found");
            
            var response = _mapper.Map<RFMARITALResponseDto>(data);
            
            return ServiceResponse<RFMARITALResponseDto>.ReturnResultWith200(response);
            
        }
    }
}