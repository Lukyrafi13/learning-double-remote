using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Queries
{
    public class RFSCOREPUTASITEMPATTINGGALsGetByCodeQuery : RFSCOREPUTASITEMPATTINGGALFindRequestDto, IRequest<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {
    }

    public class GetByCodeRFSCOREPUTASITEMPATTINGGALQueryHandler : IRequestHandler<RFSCOREPUTASITEMPATTINGGALsGetByCodeQuery, ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> _rfScoReputasiTempatTinggal;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOREPUTASITEMPATTINGGALQueryHandler(IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> rfScoReputasiTempatTinggal, IMapper mapper)
        {
            _rfScoReputasiTempatTinggal = rfScoReputasiTempatTinggal;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>> Handle(RFSCOREPUTASITEMPATTINGGALsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _rfScoReputasiTempatTinggal.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.Return404("Data RFSCOREPUTASITEMPATTINGGAL not found");
                var response = _mapper.Map<RFSCOREPUTASITEMPATTINGGALResponseDto>(data);
                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>.ReturnException(ex);
            }
        }
    }
}