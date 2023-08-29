using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPolaPengembalians;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFPolaPengembalians.Queries
{
    public class RFPolaPengembalianGetQuery : RFPolaPengembalianFindRequestDto, IRequest<ServiceResponse<RFPolaPengembalianResponseDto>>
    {
    }

    public class RFPolaPengembalianGetQueryHandler : IRequestHandler<RFPolaPengembalianGetQuery, ServiceResponse<RFPolaPengembalianResponseDto>>
    {
        private IGenericRepositoryAsync<RFPolaPengembalian> _RFPolaPengembalian;
        private readonly IMapper _mapper;

        public RFPolaPengembalianGetQueryHandler(IGenericRepositoryAsync<RFPolaPengembalian> RFPolaPengembalian, IMapper mapper)
        {
            _RFPolaPengembalian = RFPolaPengembalian;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFPolaPengembalianResponseDto>> Handle(RFPolaPengembalianGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFPolaPengembalian.GetByIdAsync(request.PolaCode, "PolaCode");
                if (data == null)
                    return ServiceResponse<RFPolaPengembalianResponseDto>.Return404("Data RFPolaPengembalian not found");
                var response = _mapper.Map<RFPolaPengembalianResponseDto>(data);
                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPolaPengembalianResponseDto>.ReturnException(ex);
            }
        }
    }
}