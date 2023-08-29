using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Apps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.Apps.Queries
{
    public class AppGudangGet : AppFind, IRequest<ServiceResponse<AppGudang>>
    {
    }

    public class AppGudangGetQueryHandler : IRequestHandler<AppGudangGet, ServiceResponse<AppGudang>>
    {
        private IGenericRepositoryAsync<App> _App;
        private readonly IMapper _mapper;

        public AppGudangGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
        {
            _App = App;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppGudang>> Handle(AppGudangGet request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _App.GetByIdAsync(request.Id, "Id", includes);

            var response = _mapper.Map<AppGudang>(data);

            return ServiceResponse<AppGudang>.ReturnResultWith200(response);
        }
    }
}