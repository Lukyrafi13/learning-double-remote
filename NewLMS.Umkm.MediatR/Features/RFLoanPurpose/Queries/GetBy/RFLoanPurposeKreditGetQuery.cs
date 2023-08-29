using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Queries
{
    public class RFLoanPurposeGetQuery : RFLoanPurposeFindRequestDto, IRequest<ServiceResponse<RFLoanPurposeResponseDto>>
    {
    }

    public class RFLoanPurposeGetQueryHandler : IRequestHandler<RFLoanPurposeGetQuery, ServiceResponse<RFLoanPurposeResponseDto>>
    {
        private IGenericRepositoryAsync<RFLoanPurpose> _RFLoanPurpose;
        private readonly IMapper _mapper;

        public RFLoanPurposeGetQueryHandler(IGenericRepositoryAsync<RFLoanPurpose> RFLoanPurpose, IMapper mapper)
        {
            _RFLoanPurpose = RFLoanPurpose;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFLoanPurposeResponseDto>> Handle(RFLoanPurposeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFLoanPurpose.GetByIdAsync(request.LP_CODE, "LP_CODE");
                if (data == null)
                    return ServiceResponse<RFLoanPurposeResponseDto>.Return404("Data RFLoanPurpose not found");
                var response = _mapper.Map<RFLoanPurposeResponseDto>(data);
                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLoanPurposeResponseDto>.ReturnException(ex);
            }
        }
    }
}