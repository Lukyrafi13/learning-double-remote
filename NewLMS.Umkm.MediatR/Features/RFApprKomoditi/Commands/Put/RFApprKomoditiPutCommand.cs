using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprKomoditis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprKomoditis.Commands
{
    public class RFApprKomoditiPutCommand : RFApprKomoditiPutRequestDto, IRequest<ServiceResponse<RFApprKomoditiResponseDto>>
    {
    }

    public class PutRFApprKomoditiCommandHandler : IRequestHandler<RFApprKomoditiPutCommand, ServiceResponse<RFApprKomoditiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFApprKomoditi> _RFApprKomoditi;
        private readonly IMapper _mapper;

        public PutRFApprKomoditiCommandHandler(IGenericRepositoryAsync<RFApprKomoditi> RFApprKomoditi, IMapper mapper)
        {
            _RFApprKomoditi = RFApprKomoditi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFApprKomoditiResponseDto>> Handle(RFApprKomoditiPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFApprKomoditi = await _RFApprKomoditi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                existingRFApprKomoditi.APPR_CODE = request.APPR_CODE;
                existingRFApprKomoditi.APPR_DESC = request.APPR_DESC;
                existingRFApprKomoditi.CORE_CODE = request.CORE_CODE;
                existingRFApprKomoditi.ACTIVE = request.ACTIVE;

                await _RFApprKomoditi.UpdateAsync(existingRFApprKomoditi);

                var response = _mapper.Map<RFApprKomoditiResponseDto>(existingRFApprKomoditi);

                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}