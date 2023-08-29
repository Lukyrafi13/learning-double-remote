using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLnkPertumbuhans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands
{
    public class RFApprTanahLnkPertumbuhanPutCommand : RFApprTanahLnkPertumbuhanPutRequestDto, IRequest<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {
    }

    public class PutRFApprTanahLnkPertumbuhanCommandHandler : IRequestHandler<RFApprTanahLnkPertumbuhanPutCommand, ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> _RFApprTanahLnkPertumbuhan;
        private readonly IMapper _mapper;

        public PutRFApprTanahLnkPertumbuhanCommandHandler(IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> RFApprTanahLnkPertumbuhan, IMapper mapper)
        {
            _RFApprTanahLnkPertumbuhan = RFApprTanahLnkPertumbuhan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>> Handle(RFApprTanahLnkPertumbuhanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFApprTanahLnkPertumbuhan = await _RFApprTanahLnkPertumbuhan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                existingRFApprTanahLnkPertumbuhan.APPR_CODE = request.APPR_CODE;
                existingRFApprTanahLnkPertumbuhan.APPR_DESC = request.APPR_DESC;
                existingRFApprTanahLnkPertumbuhan.CORE_CODE = request.CORE_CODE;
                existingRFApprTanahLnkPertumbuhan.ACTIVE = request.ACTIVE;

                await _RFApprTanahLnkPertumbuhan.UpdateAsync(existingRFApprTanahLnkPertumbuhan);

                var response = _mapper.Map<RFApprTanahLnkPertumbuhanResponseDto>(existingRFApprTanahLnkPertumbuhan);

                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}