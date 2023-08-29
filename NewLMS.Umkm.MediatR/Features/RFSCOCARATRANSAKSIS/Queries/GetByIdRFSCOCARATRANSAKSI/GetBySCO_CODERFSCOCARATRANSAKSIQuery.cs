using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFSCOCARATRANSAKSIs;
using NewLMS.Umkm.Repository.GenericRepository;
using AutoMapper;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.MediatR.Features.RFSCOCARATRANSAKSIS.Queries
{
    public class GetBySCO_CODERFSCOCARATRANSAKSIQuery : RFSCOCARATRANSAKSIFindRequestDto, IRequest<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {
    }

    public class GetBySCO_CODERFSCOCARATRANSAKSIQueryHandler : IRequestHandler<GetBySCO_CODERFSCOCARATRANSAKSIQuery, ServiceResponse<RFSCOCARATRANSAKSIResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOCARATRANSAKSI> _RFSCOCARATRANSAKSI;
        private readonly IMapper _mapper;

        public GetBySCO_CODERFSCOCARATRANSAKSIQueryHandler(IGenericRepositoryAsync<RFSCOCARATRANSAKSI> RFSCOCARATRANSAKSI, IMapper mapper)
        {
            _RFSCOCARATRANSAKSI = RFSCOCARATRANSAKSI;
            _mapper = mapper;
        }
        public async
        Task<ServiceResponse<RFSCOCARATRANSAKSIResponseDto>> Handle(GetBySCO_CODERFSCOCARATRANSAKSIQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOCARATRANSAKSI.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            if (data == null)
                return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.Return404("Data RFSCOCARATRANSAKSI not found");
            
            var response = _mapper.Map<RFSCOCARATRANSAKSIResponseDto>(data);
            
            return ServiceResponse<RFSCOCARATRANSAKSIResponseDto>.ReturnResultWith200(response);
            
        }
    }
}