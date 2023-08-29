using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Queries
{
    public class RFMappingAgunan2sGetByCodeQuery : RFMappingAgunan2FindRequestDto, IRequest<ServiceResponse<RFMappingAgunan2ResponseDto>>
    {
    }

    public class GetByCodeRFMappingAgunan2QueryHandler : IRequestHandler<RFMappingAgunan2sGetByCodeQuery, ServiceResponse<RFMappingAgunan2ResponseDto>>
    {
        private IGenericRepositoryAsync<RFMappingAgunan2> _RFMappingAgunan2;
        private readonly IMapper _mapper;

        public GetByCodeRFMappingAgunan2QueryHandler(IGenericRepositoryAsync<RFMappingAgunan2> RFMappingAgunan2, IMapper mapper)
        {
            _RFMappingAgunan2 = RFMappingAgunan2;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFMappingAgunan2ResponseDto>> Handle(RFMappingAgunan2sGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFMappingAgunan2.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFMappingAgunan2ResponseDto>.Return404("Data RFMappingAgunan2 not found");
                var response = _mapper.Map<RFMappingAgunan2ResponseDto>(data);
                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingAgunan2ResponseDto>.ReturnException(ex);
            }
        }
    }
}