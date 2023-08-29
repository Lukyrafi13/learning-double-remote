using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RFJOBs;
using NewLMS.UMKM.Repository.GenericRepository;
using AutoMapper;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.MediatR.Features.RFJOBs.Queries
{
    public class GetByIdRFJOBQuery : RFJOBFindRequestDto, IRequest<ServiceResponse<RFJOBResponseDto>>
    {
    }

    public class GetByIdRFJOBQueryHandler : IRequestHandler<GetByIdRFJOBQuery, ServiceResponse<RFJOBResponseDto>>
    {
        private IGenericRepositoryAsync<RFJOB> _RFJOB;
        private readonly IMapper _mapper;

        public GetByIdRFJOBQueryHandler(IGenericRepositoryAsync<RFJOB> RFJOB, IMapper mapper)
        {
            _RFJOB = RFJOB;
            _mapper = mapper;
        }
        public async
        Task<ServiceResponse<RFJOBResponseDto>> Handle(GetByIdRFJOBQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFJOB.GetByIdAsync(request.JOB_CODE, "JOB_CODE");
            if (data == null)
                return ServiceResponse<RFJOBResponseDto>.Return404("Data RFJOB not found");
            
            var response = _mapper.Map<RFJOBResponseDto>(data);
            
            return ServiceResponse<RFJOBResponseDto>.ReturnResultWith200(response);
            
        }
    }
}