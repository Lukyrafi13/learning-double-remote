using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprKomoditis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFApprKomoditis.Queries
{
    public class RFApprKomoditiGetQuery : RFApprKomoditiFindRequestDto, IRequest<ServiceResponse<RFApprKomoditiResponseDto>>
    {
    }

    public class RFApprKomoditiGetQueryHandler : IRequestHandler<RFApprKomoditiGetQuery, ServiceResponse<RFApprKomoditiResponseDto>>
    {
        private IGenericRepositoryAsync<RFApprKomoditi> _RFApprKomoditi;
        private readonly IMapper _mapper;

        public RFApprKomoditiGetQueryHandler(IGenericRepositoryAsync<RFApprKomoditi> RFApprKomoditi, IMapper mapper)
        {
            _RFApprKomoditi = RFApprKomoditi;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFApprKomoditiResponseDto>> Handle(RFApprKomoditiGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFApprKomoditi.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                if (data == null)
                    return ServiceResponse<RFApprKomoditiResponseDto>.Return404("Data RFApprKomoditi not found");
                var response = _mapper.Map<RFApprKomoditiResponseDto>(data);
                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprKomoditiResponseDto>.ReturnException(ex);
            }
        }
    }
}