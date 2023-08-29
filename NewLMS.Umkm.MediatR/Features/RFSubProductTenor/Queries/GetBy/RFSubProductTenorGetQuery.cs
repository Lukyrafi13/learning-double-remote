using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProductTenors;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductTenors.Queries
{
    public class RFSubProductTenorGetQuery : RFSubProductTenorFindRequestDto, IRequest<ServiceResponse<RFSubProductTenorResponseDto>>
    {
    }

    public class RFSubProductTenorGetQueryHandler : IRequestHandler<RFSubProductTenorGetQuery, ServiceResponse<RFSubProductTenorResponseDto>>
    {
        private IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private readonly IMapper _mapper;

        public RFSubProductTenorGetQueryHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper)
        {
            _RFSubProductTenor = RFSubProductTenor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSubProductTenorResponseDto>> Handle(RFSubProductTenorGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSubProductTenor.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFSubProductTenorResponseDto>.Return404("Data RFSubProductTenor not found");
                var response = _mapper.Map<RFSubProductTenorResponseDto>(data);
                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSubProductTenorResponseDto>.ReturnException(ex);
            }
        }
    }
}