using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTanahLokasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLokasis.Commands
{
    public class RFApprTanahLokasiPutCommand : RFApprTanahLokasiPutRequestDto, IRequest<ServiceResponse<RFApprTanahLokasiResponseDto>>
    {
    }

    public class PutRFApprTanahLokasiCommandHandler : IRequestHandler<RFApprTanahLokasiPutCommand, ServiceResponse<RFApprTanahLokasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLokasi> _RFApprTanahLokasi;
        private readonly IMapper _mapper;

        public PutRFApprTanahLokasiCommandHandler(IGenericRepositoryAsync<RFApprTanahLokasi> RFApprTanahLokasi, IMapper mapper)
        {
            _RFApprTanahLokasi = RFApprTanahLokasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTanahLokasiResponseDto>> Handle(RFApprTanahLokasiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFApprTanahLokasi = await _RFApprTanahLokasi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                existingRFApprTanahLokasi.APPR_CODE = request.APPR_CODE;
                existingRFApprTanahLokasi.APPR_DESC = request.APPR_DESC;
                existingRFApprTanahLokasi.CORE_CODE = request.CORE_CODE;
                existingRFApprTanahLokasi.ACTIVE = request.ACTIVE;

                await _RFApprTanahLokasi.UpdateAsync(existingRFApprTanahLokasi);

                var response = _mapper.Map<RFApprTanahLokasiResponseDto>(existingRFApprTanahLokasi);

                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLokasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}