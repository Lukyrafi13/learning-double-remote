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
//     public class AppPemohonGapoktanGet : AppFind, IRequest<ServiceResponse<AppPemohonGapoktanResponse>>
//     {
//     }

//     public class AppPemohonGapoktanGetQueryHandler : IRequestHandler<AppPemohonGapoktanGet, ServiceResponse<AppPemohonGapoktanResponse>>
//     {
//         private IGenericRepositoryAsync<App> _App;
//         private readonly IMapper _mapper;

//         public AppPemohonGapoktanGetQueryHandler(IGenericRepositoryAsync<App> App, IMapper mapper)
//         {
//             _App = App;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppPemohonGapoktanResponse>> Handle(AppPemohonGapoktanGet request, CancellationToken cancellationToken)
//         {

//             var includes = new string[]{
//                 "StatusPerkawinanKetua",
//                 "PendidikanTerakhirKetua",
//                 "KodePosKetua",
//                 "StatusPerkawinanBendahara",
//                 "PendidikanTerakhirBendahara",
//                 "KodePosBendahara",
//             };

//             var data = await _App.GetByIdAsync(request.Id, "Id", includes);

//             var response = _mapper.Map<AppPemohonGapoktanResponse>(data);

//             return ServiceResponse<AppPemohonGapoktanResponse>.ReturnResultWith200(response);
//         }
//     }
// }