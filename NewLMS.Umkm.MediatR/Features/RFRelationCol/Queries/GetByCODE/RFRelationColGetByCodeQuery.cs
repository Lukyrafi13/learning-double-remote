using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFRelationCols;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFRelationCols.Queries
{
    public class RFRelationColsGetByCodeQuery : RFRelationColFindRequestDto, IRequest<ServiceResponse<RFRelationColResponseDto>>
    {
    }

    public class GetByCodeRFRelationColQueryHandler : IRequestHandler<RFRelationColsGetByCodeQuery, ServiceResponse<RFRelationColResponseDto>>
    {
        private IGenericRepositoryAsync<RFRelationCol> _RFRelationCol;
        private readonly IMapper _mapper;

        public GetByCodeRFRelationColQueryHandler(IGenericRepositoryAsync<RFRelationCol> RFRelationCol, IMapper mapper)
        {
            _RFRelationCol = RFRelationCol;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFRelationColResponseDto>> Handle(RFRelationColsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFRelationCol.GetByIdAsync(request.ReCode, "ReCode");
                if (data == null)
                    return ServiceResponse<RFRelationColResponseDto>.Return404("Data RFRelationCol not found");
                var response = _mapper.Map<RFRelationColResponseDto>(data);
                return ServiceResponse<RFRelationColResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFRelationColResponseDto>.ReturnException(ex);
            }
        }
    }
}