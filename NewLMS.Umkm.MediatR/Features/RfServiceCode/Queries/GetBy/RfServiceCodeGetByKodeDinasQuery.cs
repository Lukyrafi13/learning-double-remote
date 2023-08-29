using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfServiceCodes.Queries
{
    public class RfServiceCodesGetByServiceCodeQuery : RfServiceCodeFindRequestDto, IRequest<ServiceResponse<RfServiceCodeResponseDto>>
    {
    }

    public class GetByIdRfServiceCodeQueryHandler : IRequestHandler<RfServiceCodesGetByServiceCodeQuery, ServiceResponse<RfServiceCodeResponseDto>>
    {
        private IGenericRepositoryAsync<RfServiceCode> _RfServiceCode;
        private readonly IMapper _mapper;

        public GetByIdRfServiceCodeQueryHandler(IGenericRepositoryAsync<RfServiceCode> RfServiceCode, IMapper mapper)
        {
            _RfServiceCode = RfServiceCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfServiceCodeResponseDto>> Handle(RfServiceCodesGetByServiceCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RfServiceCode.GetByIdAsync(request.ServiceCode, "ServiceCode");

            var response = _mapper.Map<RfServiceCodeResponseDto>(data);
            
            return ServiceResponse<RfServiceCodeResponseDto>.ReturnResultWith200(response);
        }
    }
}