using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSANDIBIS;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSANDIBIS.Commands
{
    public class RFSANDIBIPutCommand : RFSANDIBIPutRequestDto, IRequest<ServiceResponse<RFSANDIBIResponseDto>>
    {
    }

    public class PutRFSANDIBICommandHandler : IRequestHandler<RFSANDIBIPutCommand, ServiceResponse<RFSANDIBIResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSANDIBI> _RFSANDIBI;
        private readonly IMapper _mapper;

        public PutRFSANDIBICommandHandler(IGenericRepositoryAsync<RFSANDIBI> RFSANDIBI, IMapper mapper)
        {
            _RFSANDIBI = RFSANDIBI;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSANDIBIResponseDto>> Handle(RFSANDIBIPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSANDIBI = await _RFSANDIBI.GetByIdAsync(request.BI_CODE, "BI_CODE");
                existingRFSANDIBI.BI_TYPE = request.BI_TYPE;
                existingRFSANDIBI.BI_GROUP = request.BI_GROUP;
                existingRFSANDIBI.BI_CODE = request.BI_CODE;
                existingRFSANDIBI.BI_DESC = request.BI_DESC;
                existingRFSANDIBI.CORE_CODE = request.CORE_CODE;
                existingRFSANDIBI.ACTIVE = request.ACTIVE;
                existingRFSANDIBI.KATEGORI_CODE = request.KATEGORI_CODE;
                existingRFSANDIBI.LBU2_CODE = request.LBU2_CODE;

                await _RFSANDIBI.UpdateAsync(existingRFSANDIBI);

                var response = _mapper.Map<RFSANDIBIResponseDto>(existingRFSANDIBI);

                return ServiceResponse<RFSANDIBIResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSANDIBIResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}