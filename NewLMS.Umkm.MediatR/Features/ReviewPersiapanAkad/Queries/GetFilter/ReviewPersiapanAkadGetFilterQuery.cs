// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ReviewPersiapanAkads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.ReviewPersiapanAkads.Queries
// {
//     public class ReviewPersiapanAkadsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ReviewPersiapanAkadTableResponse>>>
//     {
//     }

//     public class ReviewPersiapanAkadsGetFilterQueryHandler : IRequestHandler<ReviewPersiapanAkadsGetFilterQuery, PagedResponse<IEnumerable<ReviewPersiapanAkadTableResponse>>>
//     {
//         private IGenericRepositoryAsync<ReviewPersiapanAkad> _ReviewPersiapanAkad;
//         private readonly IMapper _mapper;

//         public ReviewPersiapanAkadsGetFilterQueryHandler(
//             IGenericRepositoryAsync<ReviewPersiapanAkad> ReviewPersiapanAkad,
//             IMapper mapper)
//         {
//             _ReviewPersiapanAkad = ReviewPersiapanAkad;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<ReviewPersiapanAkadTableResponse>>> Handle(ReviewPersiapanAkadsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "App",
//                 "App.KodePos",
//                 "App.JenisProduk",
//                 "App.BookingOffice",
//                 "App.Prospect",
//                 "App.Prospect.ProspectStageLogs",
//                 "App.Prospect.ProspectStageLogs.RFStages",
//                 "App.TipeDebitur",
//                 "SPPK",
//                 "Analisa",
//                 "Prescreening",
//             };

//             var data = await _ReviewPersiapanAkad.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<ReviewPersiapanAkadTableResponse>>(data.Results);
//             IEnumerable<ReviewPersiapanAkadTableResponse> dataVm;
//             var listResponse = new List<ReviewPersiapanAkadTableResponse>();

//             foreach (var res in data.Results)
//             {
//                 var response = new ReviewPersiapanAkadTableResponse();

//                 response.Id = res.Id;
//                 response.App = res.App;
//                 response.Prescreening = res.Prescreening;
//                 response.SPPK = res.SPPK;
//                 response.Analisa = res.Analisa;
//                 response.PersiapanAkad = res.PersiapanAkad;

//                 response.Age = res.Age;


//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<ReviewPersiapanAkadTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }