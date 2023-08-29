using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Queries
{
    public class RFAspekPemasaranGetQuery : RFAspekPemasaranFindRequestDto, IRequest<ServiceResponse<RFAspekPemasaranResponseDto>>
    {
    }

    public class RFAspekPemasaranGetQueryHandler : IRequestHandler<RFAspekPemasaranGetQuery, ServiceResponse<RFAspekPemasaranResponseDto>>
    {
        private IGenericRepositoryAsync<RFAspekPemasaran> _RFAspekPemasaran;
        private readonly IMapper _mapper;

        public RFAspekPemasaranGetQueryHandler(IGenericRepositoryAsync<RFAspekPemasaran> RFAspekPemasaran, IMapper mapper)
        {
            _RFAspekPemasaran = RFAspekPemasaran;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFAspekPemasaranResponseDto>> Handle(RFAspekPemasaranGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFAspekPemasaran.GetByIdAsync(request.ANL_CODE, "ANL_CODE");
                if (data == null)
                    return ServiceResponse<RFAspekPemasaranResponseDto>.Return404("Data RFAspekPemasaran not found");
                var response = _mapper.Map<RFAspekPemasaranResponseDto>(data);
                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFAspekPemasaranResponseDto>.ReturnException(ex);
            }
        }
    }
}