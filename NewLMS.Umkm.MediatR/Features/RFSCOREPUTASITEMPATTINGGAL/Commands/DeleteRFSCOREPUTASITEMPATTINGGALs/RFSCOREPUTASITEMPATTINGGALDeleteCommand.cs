using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Commands
{
    public class RFSCOREPUTASITEMPATTINGGALDeleteCommand : RFSCOREPUTASITEMPATTINGGALFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSCOREPUTASITEMPATTINGGALCommandHandler : IRequestHandler<RFSCOREPUTASITEMPATTINGGALDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> _rfScoReputasiTempatTinggal;
        private readonly IMapper _mapper;

        public DeleteRFSCOREPUTASITEMPATTINGGALCommandHandler(IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> rfScoReputasiTempatTinggal, IMapper mapper){
            _rfScoReputasiTempatTinggal = rfScoReputasiTempatTinggal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSCOREPUTASITEMPATTINGGALDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _rfScoReputasiTempatTinggal.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
            rFProduct.IsDeleted = true;
            await _rfScoReputasiTempatTinggal.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}