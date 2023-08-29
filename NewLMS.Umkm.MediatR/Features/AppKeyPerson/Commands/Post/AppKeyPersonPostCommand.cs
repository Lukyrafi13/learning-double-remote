// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppKeyPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppKeyPersons.Commands
// {
//     public class AppKeyPersonPostCommand : AppKeyPersonPostRequestDto, IRequest<ServiceResponse<AppKeyPersonResponseDto>>
//     {

//     }
//     public class AppKeyPersonPostCommandHandler : IRequestHandler<AppKeyPersonPostCommand, ServiceResponse<AppKeyPersonResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IMapper _mapper;

//         public AppKeyPersonPostCommandHandler(IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson, IMapper mapper)
//         {
//             _AppKeyPerson = AppKeyPerson;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppKeyPersonResponseDto>> Handle(AppKeyPersonPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var AppKeyPerson = _mapper.Map<AppKeyPerson>(request);

//                 var returnedAppKeyPerson = await _AppKeyPerson.AddAsync(AppKeyPerson, callSave: false);

//                 // var response = _mapper.Map<AppKeyPersonResponseDto>(returnedAppKeyPerson);
//                 var response = _mapper.Map<AppKeyPersonResponseDto>(returnedAppKeyPerson);

//                 await _AppKeyPerson.SaveChangeAsync();
//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }