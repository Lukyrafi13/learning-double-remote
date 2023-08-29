using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLinkages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFLinkages.Queries
{
    public class RFLinkageGetQuery : RFLinkageFindRequestDto, IRequest<ServiceResponse<RFLinkageResponseDto>>
    {
    }

    public class RFLinkageGetQueryHandler : IRequestHandler<RFLinkageGetQuery, ServiceResponse<RFLinkageResponseDto>>
    {
        private IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private readonly IMapper _mapper;

        public RFLinkageGetQueryHandler(IGenericRepositoryAsync<RFLinkage> RFLinkage, IMapper mapper)
        {
            _RFLinkage = RFLinkage;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFLinkageResponseDto>> Handle(RFLinkageGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFLinkage.GetByIdAsync(request.LinkCode, "LinkCode");
                if (data == null)
                    return ServiceResponse<RFLinkageResponseDto>.Return404("Data RFLinkage not found");
                var response = _mapper.Map<RFLinkageResponseDto>(data);
                return ServiceResponse<RFLinkageResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFLinkageResponseDto>.ReturnException(ex);
            }
        }
    }
}