// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Disbursements;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.Disbursements.Queries
// {
//     public class DisbursementsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<DisbursementTableResponse>>>
//     {
//     }

//     public class DisbursementsGetFilterQueryHandler : IRequestHandler<DisbursementsGetFilterQuery, PagedResponse<IEnumerable<DisbursementTableResponse>>>
//     {
//         private IGenericRepositoryAsync<Disbursement> _Disbursement;
//         private readonly IMapper _mapper;

//         public DisbursementsGetFilterQueryHandler(
//             IGenericRepositoryAsync<Disbursement> Disbursement,
//             IMapper mapper)
//         {
//             _Disbursement = Disbursement;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<DisbursementTableResponse>>> Handle(DisbursementsGetFilterQuery request, CancellationToken cancellationToken)
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
//                 "PersiapanAkad",
//             };

//             var data = await _Disbursement.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<DisbursementTableResponse>>(data.Results);
//             IEnumerable<DisbursementTableResponse> dataVm;
//             var listResponse = new List<DisbursementTableResponse>();

//             foreach (var res in data.Results)
//             {
//                 var response = new DisbursementTableResponse();

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
//             return new PagedResponse<IEnumerable<DisbursementTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }