using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFEDUCATIONs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFEDUCATIONs.Queries
{
    public class RFEDUCATIONsGetByEducationCodeQuery : RFEDUCATIONFindRequestDto, IRequest<ServiceResponse<RFEDUCATIONResponseDto>>
    {
    }

    public class GetByIdRFEDUCATIONQueryHandler : IRequestHandler<RFEDUCATIONsGetByEducationCodeQuery, ServiceResponse<RFEDUCATIONResponseDto>>
    {
        private IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private readonly IMapper _mapper;

        public GetByIdRFEDUCATIONQueryHandler(IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION, IMapper mapper)
        {
            _RFEDUCATION = RFEDUCATION;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFEDUCATIONResponseDto>> Handle(RFEDUCATIONsGetByEducationCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RFEDUCATION.GetByIdAsync(request.ED_CODE, "ED_CODE");

            var response = _mapper.Map<RFEDUCATIONResponseDto>(data);
            
            return ServiceResponse<RFEDUCATIONResponseDto>.ReturnResultWith200(response);
        }
    }
}