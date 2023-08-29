// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Queries
// {
//     public class AppTableGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppTableResponse>>>
//     {
//     }

//     public class AppTableGetFilterQueryHandler : IRequestHandler<AppTableGetFilterQuery, PagedResponse<IEnumerable<AppTableResponse>>>
//     {
//         private IGenericRepositoryAsync<App> _App;
//         private IGenericRepositoryAsync<ProspectStageLogs> _ProspectStageLogs;
//         private readonly IMapper _mapper;

//         public AppTableGetFilterQueryHandler(
//                 IGenericRepositoryAsync<App> App,
//                 IGenericRepositoryAsync<ProspectStageLogs> ProspectStageLogs,
//                 IMapper mapper
//             )
//         {
//             _App = App;
//             _ProspectStageLogs = ProspectStageLogs;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AppTableResponse>>> Handle(AppTableGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[] {
//                 "JenisProduk",
//                 "TipeDebitur",
//                 "Prospect",
//                 "Prospect.Stage",
//                 "Prospect.ProspectStageLogs",
//                 "Prospect.ProspectStageLogs.RFStages",
//             };
//             var data = await _App.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AppTableResponse>>(data.Results);
//             IEnumerable<AppTableResponse> dataVm;
//             var listResponse = new List<AppTableResponse>();

//             foreach (var result in data.Results){
//                 var response = new AppTableResponse();

//                 var log = await _ProspectStageLogs.GetByPredicate(x => x.ProspectId == result.ProspectId && x.StageId == result.Prospect.RFStagesId );

//                 response.Id = result.Id;
//                 response.AplikasiId = result.AplikasiId;
//                 response.CustomerName = result.NamaCustomer;
//                 response.BookingOffice = result.KodeCabang +" - "+result.NamaCabang;
//                 response.NamaAO = result.NamaAO;
//                 response.ProductLengkap = result.JenisProduk.ProductDesc +" - "+result.TipeDebitur.OwnDesc;
//                 response.Product = result.JenisProduk.ProductDesc;
//                 var age = DateTime.Now - log.CreatedDate;
//                 response.Aging = Convert.ToInt32(age.TotalDays).ToString() + " HARI";
//                 response.SumberData = result.SumberData;
//                 response.Stage = result.Prospect.Stage;
//                 response.Age = result.Prospect.Age??-1;

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AppTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }