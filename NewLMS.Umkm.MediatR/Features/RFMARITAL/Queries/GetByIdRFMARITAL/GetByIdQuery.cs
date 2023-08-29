using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFMARITALs;
using NewLMS.Umkm.Repository.GenericRepository;
using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Queries
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