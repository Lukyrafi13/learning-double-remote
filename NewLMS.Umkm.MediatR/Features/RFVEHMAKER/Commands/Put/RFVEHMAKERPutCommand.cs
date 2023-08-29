using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHMAKERs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHMAKERs.Commands
{
    public class RFVEHMAKERPutCommand : RFVEHMAKERPutRequestDto, IRequest<ServiceResponse<RFVEHMAKERResponseDto>>
    {
    }

    public class PutRFVEHMAKERCommandHandler : IRequestHandler<RFVEHMAKERPutCommand, ServiceResponse<RFVEHMAKERResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHMAKER> _RFVEHMAKER;
        private readonly IMapper _mapper;

        public PutRFVEHMAKERCommandHandler(IGenericRepositoryAsync<RFVEHMAKER> RFVEHMAKER, IMapper mapper){
            _RFVEHMAKER = RFVEHMAKER;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHMAKERResponseDto>> Handle(RFVEHMAKERPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFVEHMAKER = await _RFVEHMAKER.GetByIdAsync(request.VMKR_CODE, "VMKR_CODE");
                existingRFVEHMAKER.VMKR_CODE = request.VMKR_CODE;
                existingRFVEHMAKER.VMKR_DESC = request.VMKR_DESC;
                existingRFVEHMAKER.CORE_CODE = request.CORE_CODE;
                existingRFVEHMAKER.ACTIVE = request.ACTIVE;
                existingRFVEHMAKER.VEH_CODE = request.VEH_CODE;
                existingRFVEHMAKER.VCNT_CODE = request.VCNT_CODE;
                
                await _RFVEHMAKER.UpdateAsync(existingRFVEHMAKER);

                var response = _mapper.Map<RFVEHMAKERResponseDto>(existingRFVEHMAKER);

                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHMAKERResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}