using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Commands
{
    public class RFSifatKreditPutCommand : RFSifatKreditPutRequestDto, IRequest<ServiceResponse<RFSifatKreditResponseDto>>
    {
    }

    public class PutRFSifatKreditCommandHandler : IRequestHandler<RFSifatKreditPutCommand, ServiceResponse<RFSifatKreditResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSifatKredit> _RFSifatKredit;
        private readonly IMapper _mapper;

        public PutRFSifatKreditCommandHandler(IGenericRepositoryAsync<RFSifatKredit> RFSifatKredit, IMapper mapper){
            _RFSifatKredit = RFSifatKredit;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSifatKreditResponseDto>> Handle(RFSifatKreditPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFSifatKredit = await _RFSifatKredit.GetByIdAsync(request.SKCode, "SKCode");
                existingRFSifatKredit.SKCode = request.SKCode;
                existingRFSifatKredit.SKDesc = request.SKDesc;
                existingRFSifatKredit.CoreCode = request.CoreCode;
                existingRFSifatKredit.Active = request.Active;
                
                await _RFSifatKredit.UpdateAsync(existingRFSifatKredit);

                var response = _mapper.Map<RFSifatKreditResponseDto>(existingRFSifatKredit);

                return ServiceResponse<RFSifatKreditResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSifatKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}