// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Queries
// {
//     public class SlikRequestsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SlikRequestTableResponse>>>
//     {
//     }

//     public class SlikRequestsGetFilterQueryHandler : IRequestHandler<SlikRequestsGetFilterQuery, PagedResponse<IEnumerable<SlikRequestTableResponse>>>
//     {
//         private IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IMapper _mapper;

//         public SlikRequestsGetFilterQueryHandler(IGenericRepositoryAsync<SlikRequest> SlikRequest, IMapper mapper)
//         {
//             _SlikRequest = SlikRequest;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<SlikRequestTableResponse>>> Handle(SlikRequestsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "App",
//                 "App.KodePos",
//                 "App.TipeDebitur",
//                 "App.JenisProduk",
//                 "App.BookingOffice",
//                 "App.Prospect",
//                 "SlikRequestObjects",
//                 "App.StatusPerkawinan",
//                 "App.DataPekerjaan",
//                 "App.PendidikanTerakhir",
//                 "App.StatusTempatTinggal",
//                 "App.Prospect.ProspectStageLogs",
//                 "App.Prospect.ProspectStageLogs.RFStages",
//             };

//             var data = await _SlikRequest.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<SlikRequestTableResponse>>(data.Results);
//             IEnumerable<SlikRequestTableResponse> dataVm;
//             var listResponse = new List<SlikRequestTableResponse>();

//             foreach (var res in data.Results){
//                 var response = new SlikRequestTableResponse();

//                 response.Id = res.Id;

//                 response.SlikRequestObjects = res.SlikRequestObjects;

//                 response.App = res.App;
//                 response.Age = res.Age;
                
//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<SlikRequestTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }