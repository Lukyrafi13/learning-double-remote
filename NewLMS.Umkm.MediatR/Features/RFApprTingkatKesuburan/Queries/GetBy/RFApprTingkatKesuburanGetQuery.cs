using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTingkatKesuburans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFApprTingkatKesuburans.Queries
{
    public class RFApprTingkatKesuburanGetQuery : RFApprTingkatKesuburanFindRequestDto, IRequest<ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {
    }

    public class RFApprTingkatKesuburanGetQueryHandler : IRequestHandler<RFApprTingkatKesuburanGetQuery, ServiceResponse<RFApprTingkatKesuburanResponseDto>>
    {
        private IGenericRepositoryAsync<RFApprTingkatKesuburan> _RFApprTingkatKesuburan;
        private readonly IMapper _mapper;

        public RFApprTingkatKesuburanGetQueryHandler(IGenericRepositoryAsync<RFApprTingkatKesuburan> RFApprTingkatKesuburan, IMapper mapper)
        {
            _RFApprTingkatKesuburan = RFApprTingkatKesuburan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFApprTingkatKesuburanResponseDto>> Handle(RFApprTingkatKesuburanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFApprTingkatKesuburan.GetByIdAsync(request.APPR_CODE, "APPR_CODE");
                if (data == null)
                    return ServiceResponse<RFApprTingkatKesuburanResponseDto>.Return404("Data RFApprTingkatKesuburan not found");
                var response = _mapper.Map<RFApprTingkatKesuburanResponseDto>(data);
                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFApprTingkatKesuburanResponseDto>.ReturnException(ex);
            }
        }
    }
}