using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMARITALs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Commands
{
    public class RFMARITALPutCommand : RFMARITALPutRequestDto, IRequest<ServiceResponse<RFMARITALResponseDto>>
    {

    }
    public class PutRFSCOCARATRANSKASICommandHandler : IRequestHandler<RFMARITALPutCommand, ServiceResponse<RFMARITALResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IMapper _mapper;

        public PutRFSCOCARATRANSKASICommandHandler(IGenericRepositoryAsync<RFMARITAL> RFMARITAL, IMapper mapper)
        {
            _RFMARITAL = RFMARITAL;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFMARITALResponseDto>> Handle(RFMARITALPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFMARITAL = await _RFMARITAL.GetByIdAsync(request.MR_CODE, "MR_CODE");
                existingRFMARITAL.MR_CODE = request.MR_CODE;
                existingRFMARITAL.MR_DESC = request.MR_DESC;
                existingRFMARITAL.CORE_CODE = request.CORE_CODE;
                existingRFMARITAL.WITHSPOUSE = request.WITHSPOUSE;
                existingRFMARITAL.ACTIVE = request.ACTIVE;
                existingRFMARITAL.MR_CODESIKP = request.MR_CODESIKP;
                existingRFMARITAL.MR_DESCSIKP = request.MR_DESCSIKP;

                await _RFMARITAL.UpdateAsync(existingRFMARITAL);

                var response = _mapper.Map<RFMARITALResponseDto>(existingRFMARITAL);


                return ServiceResponse<RFMARITALResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMARITALResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}