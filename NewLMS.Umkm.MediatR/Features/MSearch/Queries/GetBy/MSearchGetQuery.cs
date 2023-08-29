using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.MSearchs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.MSearchs.Queries
{
    public class MSearchGetQuery : MSearchFindRequestDto, IRequest<ServiceResponse<MSearchResponseDto>>
    {
    }

    public class MSearchGetQueryHandler : IRequestHandler<MSearchGetQuery, ServiceResponse<MSearchResponseDto>>
    {
        private IGenericRepositoryAsync<MSearch> _MSearch;
        private readonly IMapper _mapper;

        public MSearchGetQueryHandler(IGenericRepositoryAsync<MSearch> MSearch, IMapper mapper)
        {
            _MSearch = MSearch;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<MSearchResponseDto>> Handle(MSearchGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _MSearch.GetByIdAsync(request.TypeId, "TypeId");
                if (data == null)
                    return ServiceResponse<MSearchResponseDto>.Return404("Data MSearch not found");
                var response = _mapper.Map<MSearchResponseDto>(data);
                return ServiceResponse<MSearchResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<MSearchResponseDto>.ReturnException(ex);
            }
        }
    }
}