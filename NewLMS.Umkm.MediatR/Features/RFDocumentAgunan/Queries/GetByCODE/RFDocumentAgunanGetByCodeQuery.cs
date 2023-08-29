using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDocumentAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFDocumentAgunans.Queries
{
    public class RFDocumentAgunansGetByCodeQuery : RFDocumentAgunanFindRequestDto, IRequest<ServiceResponse<RFDocumentAgunanResponseDto>>
    {
    }

    public class GetByCodeRFDocumentAgunanQueryHandler : IRequestHandler<RFDocumentAgunansGetByCodeQuery, ServiceResponse<RFDocumentAgunanResponseDto>>
    {
        private IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IMapper _mapper;

        public GetByCodeRFDocumentAgunanQueryHandler(IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan, IMapper mapper)
        {
            _RFDocumentAgunan = RFDocumentAgunan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFDocumentAgunanResponseDto>> Handle(RFDocumentAgunansGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFDocumentAgunan.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFDocumentAgunanResponseDto>.Return404("Data RFDocumentAgunan not found");
                var response = _mapper.Map<RFDocumentAgunanResponseDto>(data);
                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnException(ex);
            }
        }
    }
}