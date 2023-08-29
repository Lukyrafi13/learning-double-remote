// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Approvals;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.Approvals.Queries
// {
//     public class ApprovalsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ApprovalTableResponse>>>
//     {
//     }

//     public class ApprovalsGetFilterQueryHandler : IRequestHandler<ApprovalsGetFilterQuery, PagedResponse<IEnumerable<ApprovalTableResponse>>>
//     {
//         private IGenericRepositoryAsync<Approval> _Approval;
//         private readonly IMapper _mapper;

//         public ApprovalsGetFilterQueryHandler(
//             IGenericRepositoryAsync<Approval> Approval,
//             IMapper mapper)
//         {
//             _Approval = Approval;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<ApprovalTableResponse>>> Handle(ApprovalsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "App",
//                 "App.KodePos",
//                 "App.JenisProduk",
//                 "App.BookingOffice",
//                 "App.Prospect",
//                 "App.TipeDebitur",
//                 "App.Prospect.ProspectStageLogs",
//                 "App.Prospect.ProspectStageLogs.RFStages",
//                 "Prescreening",
//                 "Survey",
//                 "Analisa",
//                 "Analisa.Survey",
//                 "SlikRequest",
//             };

//             var data = await _Approval.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<ApprovalTableResponse>>(data.Results);
//             IEnumerable<ApprovalTableResponse> dataVm;
//             var listResponse = new List<ApprovalTableResponse>();

//             foreach (var res in data.Results){
//                 var response = new ApprovalTableResponse();

//                 response.Id = res.Id;
//                 response.App = res.App;
//                 response.Prescreening = res.Prescreening;
//                 response.Survey = res.Survey;
//                 response.Analisa = res.Analisa;
//                 response.SlikRequest = res.SlikRequest;
//                 response.Age = res.Age;
                
//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<ApprovalTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }