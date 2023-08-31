// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Apps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Apps.Commands
// {
//     public class AppPilihanPemutusPutCommand : AppPilihanPemutusPutRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }
//     public class AppPilihanPemutusPutCommandHandler : IRequestHandler<AppPilihanPemutusPutCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<App> _app;
//         private readonly IGenericRepositoryAsync<RfZipCode> _zipCode;
//         private readonly IMapper _mapper;

//         public AppPilihanPemutusPutCommandHandler(
//             IGenericRepositoryAsync<App> app,
//             IGenericRepositoryAsync<RfZipCode> zipCode,
//             IMapper mapper)
//         {
//             _app = app;
//             _zipCode = zipCode;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppPilihanPemutusPutCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var existingApp = await _app.GetByIdAsync(request.Id, "Id");

//                 existingApp.RFPilihanPemutusId = request.RFPilihanPemutusId;

//                 await _app.UpdateAsync(existingApp);
//                 return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }