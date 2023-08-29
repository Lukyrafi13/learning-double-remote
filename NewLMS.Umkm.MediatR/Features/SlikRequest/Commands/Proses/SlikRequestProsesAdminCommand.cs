// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;
// using System.Collections.Generic;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequests.Commands
// {
//     public class SlikRequestProsesAdminCommand : IRequest<ServiceResponse<SlikRequestProsesAdminResponse>>
//     {
//         public List<SlikRequestFind> listSlikRequestFinds;
//     }
//     public class SlikRequestProsesAdminCommandHandler : IRequestHandler<SlikRequestProsesAdminCommand, ServiceResponse<SlikRequestProsesAdminResponse>>
//     {
//         private readonly IGenericRepositoryAsync<App> _App;
//         private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
//         private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
//         private readonly IGenericRepositoryAsync<SlikRequest> _SlikRequest;
//         private readonly IMapper _mapper;

//         public SlikRequestProsesAdminCommandHandler(
//                 IGenericRepositoryAsync<App> App,
//                 IGenericRepositoryAsync<AppAgunan> AppAgunan,
//                 IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject,
//                 IGenericRepositoryAsync<SlikRequest> SlikRequest,
//                 IMapper mapper
//             )
//         {
//             _App = App;
//             _SlikRequestObject = SlikRequestObject;
//             _SlikRequest = SlikRequest;
//             _AppAgunan = AppAgunan;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SlikRequestProsesAdminResponse>> Handle(SlikRequestProsesAdminCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var listSlikRequest = new List<SlikRequest>();

//                 foreach (var SlikRequestFind in request.listSlikRequestFinds)
//                 {

//                     var SlikRequest = await _SlikRequest.GetByIdAsync(SlikRequestFind.Id, "Id",
//                         new string[] {
//                             "App",
//                             "App.Prospect",
//                             "App.Prospect.Stage"
//                         }
//                     );

//                     var AgunanCount = await _AppAgunan.GetCountByPredicate(x=>x.AppId == SlikRequest.AppId);

//                     if (SlikRequest == null)
//                     {
//                         var failResp = ServiceResponse<SlikRequestProsesAdminResponse>.Return404("Data SlikRequest not found");
//                         failResp.Success = false;
//                         return failResp;
//                     }

//                     // TODO : Tembak ke RoboSLIK

//                     SlikRequest.ProcessStatus = 1;

//                     if (AgunanCount < 1){
//                         SlikRequest.AdminVerified = 1;
//                     }

//                     await _SlikRequest.UpdateAsync(SlikRequest);
                    
//                     var listSlikRequestObject = await _SlikRequestObject.GetListByPredicate(x=> x.SlikRequestId == SlikRequest.Id);
                    
//                     foreach (var SlikRequestObject in listSlikRequestObject){
//                         SlikRequestObject.RequestDate = DateTime.Now;

//                         await _SlikRequestObject.UpdateAsync(SlikRequestObject);
//                     }
//                 }
//                 var response = new SlikRequestProsesAdminResponse();

//                 response.Message = "SlikRequest berhasil diproses ke panel admin";

//                 return ServiceResponse<SlikRequestProsesAdminResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 var response = ServiceResponse<SlikRequestProsesAdminResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//                 response.Success = false;
//                 return response;
//             }
//         }
//     }
// }