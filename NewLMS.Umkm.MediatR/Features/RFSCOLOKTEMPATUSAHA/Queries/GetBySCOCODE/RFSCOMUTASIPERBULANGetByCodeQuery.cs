using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Queries
{
    public class RFSCOLOKTEMPATUSAHAsGetByCodeQuery : RFSCOLOKTEMPATUSAHAFindRequestDto, IRequest<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {
    }

    public class GetByCodeRFSCOLOKTEMPATUSAHAQueryHandler : IRequestHandler<RFSCOLOKTEMPATUSAHAsGetByCodeQuery, ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> _RFSCOLOKTEMPATUSAHA;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOLOKTEMPATUSAHAQueryHandler(IGenericRepositoryAsync<RFSCOLOKTEMPATUSAHA> RFSCOLOKTEMPATUSAHA, IMapper mapper)
        {
            _RFSCOLOKTEMPATUSAHA = RFSCOLOKTEMPATUSAHA;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>> Handle(RFSCOLOKTEMPATUSAHAsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOLOKTEMPATUSAHA.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.Return404("Data RFSCOLOKTEMPATUSAHA not found");
                var response = _mapper.Map<RFSCOLOKTEMPATUSAHAResponseDto>(data);
                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>.ReturnException(ex);
            }
        }
    }
}