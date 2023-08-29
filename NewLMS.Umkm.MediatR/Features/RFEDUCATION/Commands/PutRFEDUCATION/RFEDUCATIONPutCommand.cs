using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Commands
{
    public class RFEDUCATIONPutCommand : RFEDUCATIONPutRequestDto, IRequest<ServiceResponse<RFEDUCATIONResponseDto>>
    {
    }

    public class PutRFEDUCATIONCommandHandler : IRequestHandler<RFEDUCATIONPutCommand, ServiceResponse<RFEDUCATIONResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFEDUCATION> _RFEDUCATION;
        private readonly IMapper _mapper;

        public PutRFEDUCATIONCommandHandler(IGenericRepositoryAsync<RFEDUCATION> RFEDUCATION, IMapper mapper){
            _RFEDUCATION = RFEDUCATION;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFEDUCATIONResponseDto>> Handle(RFEDUCATIONPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFEDUCATION = await _RFEDUCATION.GetByIdAsync(request.ED_CODE, "ED_CODE");
                existingRFEDUCATION.ED_CODE = request.ED_CODE;
                existingRFEDUCATION.ED_DESC = request.ED_DESC;
                existingRFEDUCATION.ED_CODESIKP = request.ED_CODESIKP;
                existingRFEDUCATION.ED_DESCSIKP = request.ED_DESCSIKP;
                existingRFEDUCATION.CORE_CODE = request.CORE_CODE;
                existingRFEDUCATION.ACTIVE = request.ACTIVE;
                
                await _RFEDUCATION.UpdateAsync(existingRFEDUCATION);

                var response = _mapper.Map<RFEDUCATIONResponseDto>(existingRFEDUCATION);

                return ServiceResponse<RFEDUCATIONResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFEDUCATIONResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}