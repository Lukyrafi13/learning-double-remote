using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFMappingLBU3s;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFMappingLBU3s.Queries
{
    public class RFMappingLBU3GetQuery : RFMappingLBU3FindRequestDto, IRequest<ServiceResponse<RFMappingLBU3ResponseDto>>
    {
    }

    public class RFMappingLBU3GetQueryHandler : IRequestHandler<RFMappingLBU3GetQuery, ServiceResponse<RFMappingLBU3ResponseDto>>
    {
        private IGenericRepositoryAsync<RFMappingLBU3> _RFMappingLBU3;
        private readonly IMapper _mapper;

        public RFMappingLBU3GetQueryHandler(IGenericRepositoryAsync<RFMappingLBU3> RFMappingLBU3, IMapper mapper)
        {
            _RFMappingLBU3 = RFMappingLBU3;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFMappingLBU3ResponseDto>> Handle(RFMappingLBU3GetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFMappingLBU3.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFMappingLBU3ResponseDto>.Return404("Data RFMappingLBU3 not found");
                var response = _mapper.Map<RFMappingLBU3ResponseDto>(data);
                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingLBU3ResponseDto>.ReturnException(ex);
            }
        }
    }
}