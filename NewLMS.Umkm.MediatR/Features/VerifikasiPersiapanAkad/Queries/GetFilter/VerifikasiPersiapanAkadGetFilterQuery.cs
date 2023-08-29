// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.VerifikasiPersiapanAkads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.VerifikasiPersiapanAkads.Queries
// {
//     public class VerifikasiPersiapanAkadsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<VerifikasiPersiapanAkadTableResponse>>>
//     {
//     }

//     public class VerifikasiPersiapanAkadsGetFilterQueryHandler : IRequestHandler<VerifikasiPersiapanAkadsGetFilterQuery, PagedResponse<IEnumerable<VerifikasiPersiapanAkadTableResponse>>>
//     {
//         private IGenericRepositoryAsync<VerifikasiPersiapanAkad> _VerifikasiPersiapanAkad;
//         private readonly IMapper _mapper;

//         public VerifikasiPersiapanAkadsGetFilterQueryHandler(
//             IGenericRepositoryAsync<VerifikasiPersiapanAkad> VerifikasiPersiapanAkad,
//             IMapper mapper)
//         {
//             _VerifikasiPersiapanAkad = VerifikasiPersiapanAkad;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<VerifikasiPersiapanAkadTableResponse>>> Handle(VerifikasiPersiapanAkadsGetFilterQuery request, CancellationToken cancellationToken)
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

//             var data = await _VerifikasiPersiapanAkad.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<VerifikasiPersiapanAkadTableResponse>>(data.Results);
//             IEnumerable<VerifikasiPersiapanAkadTableResponse> dataVm;
//             var listResponse = new List<VerifikasiPersiapanAkadTableResponse>();

//             foreach (var res in data.Results)
//             {
//                 var response = new VerifikasiPersiapanAkadTableResponse();

//                 response.Id = res.Id;
//                 response.App = res.App;
//                 response.Prescreening = res.Prescreening;
//                 response.SPPK = res.SPPK;
//                 response.Analisa = res.Analisa;
//                 response.Age = res.Age;
//                 response.PersiapanAkad = res.PersiapanAkad;


//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<VerifikasiPersiapanAkadTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }