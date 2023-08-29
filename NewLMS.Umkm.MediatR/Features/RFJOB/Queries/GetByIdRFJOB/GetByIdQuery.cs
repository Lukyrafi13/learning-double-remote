using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFJOBs;
using NewLMS.Umkm.Repository.GenericRepository;
using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.MediatR.Features.RFJOBs.Queries
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