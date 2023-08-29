// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppContactPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppContactPersons.Commands
// {
//     public class AppContactPersonPostCommand : AppContactPersonPostRequestDto, IRequest<ServiceResponse<AppContactPersonResponseDto>>
//     {

//     }
//     public class AppContactPersonPostCommandHandler : IRequestHandler<AppContactPersonPostCommand, ServiceResponse<AppContactPersonResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppContactPerson> _AppContactPerson;
//         private readonly IMapper _mapper;

//         public AppContactPersonPostCommandHandler(IGenericRepositoryAsync<AppContactPerson> AppContactPerson, IMapper mapper)
//         {
//             _AppContactPerson = AppContactPerson;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppContactPersonResponseDto>> Handle(AppContactPersonPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var AppContactPerson = _mapper.Map<AppContactPerson>(request);

//                 var returnedAppContactPerson = await _AppContactPerson.AddAsync(AppContactPerson, callSave: false);

//                 // var response = _mapper.Map<AppContactPersonResponseDto>(returnedAppContactPerson);
//                 var response = _mapper.Map<AppContactPersonResponseDto>(returnedAppContactPerson);

//                 await _AppContactPerson.SaveChangeAsync();
//                 return ServiceResponse<AppContactPersonResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppContactPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }