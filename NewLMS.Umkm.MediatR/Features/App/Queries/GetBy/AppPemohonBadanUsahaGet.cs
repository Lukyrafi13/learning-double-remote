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
//     public class AppPemohonBadanUsahaGet : AppFind, IRequest<ServiceResponse<AppPemohonBadanUsahaResponse>>
//     {
//     }

//     public class AppPemohonBadanUsahaGetQueryHandler : IRequestHandler<AppPemohonBadanUsahaGet, ServiceResponse<AppPemohonBadanUsahaResponse>>
//     {
//         private IGenericRepositoryAsync<App> _App;
//         private readonly IMapper _mapper;

//         public AppPemohonBadanUsahaGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
//         {
//             _App = App;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppPemohonBadanUsahaResponse>> Handle(AppPemohonBadanUsahaGet request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "KodePos",
//                 "KodePosKontakDarurat",
//             };

//             var data = await _App.GetByIdAsync(request.Id, "Id", includes);

//             var response = _mapper.Map<AppPemohonBadanUsahaResponse>(data);

//             return ServiceResponse<AppPemohonBadanUsahaResponse>.ReturnResultWith200(response);
//         }
//     }
// }