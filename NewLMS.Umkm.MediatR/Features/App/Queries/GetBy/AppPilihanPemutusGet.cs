// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Queries
// {
//     public class AppPilihanPemutusGet : AppFind, IRequest<ServiceResponse<AppPilihanPemutusResponse>>
//     {
//     }

//     public class AppPilihanPemutusGetQueryHandler : IRequestHandler<AppPilihanPemutusGet, ServiceResponse<AppPilihanPemutusResponse>>
//     {
//         private IGenericRepositoryAsync<App> _App;
//         private readonly IMapper _mapper;

//         public AppPilihanPemutusGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
//         {
//             _App = App;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppPilihanPemutusResponse>> Handle(AppPilihanPemutusGet request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "PilihanPemutus",
//             };

//             var data = await _App.GetByIdAsync(request.Id, "Id", includes);

//             var response = _mapper.Map<AppPilihanPemutusResponse>(data);

//             return ServiceResponse<AppPilihanPemutusResponse>.ReturnResultWith200(response);
//         }
//     }
// }