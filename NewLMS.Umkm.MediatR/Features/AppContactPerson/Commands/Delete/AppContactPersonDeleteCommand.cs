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
//     public class AppContactPersonDeleteCommand : AppContactPersonFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteAppContactPersonCommandHandler : IRequestHandler<AppContactPersonDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<AppContactPerson> _AppContactPerson;
//         private readonly IMapper _mapper;

//         public DeleteAppContactPersonCommandHandler(IGenericRepositoryAsync<AppContactPerson> AppContactPerson, IMapper mapper){
//             _AppContactPerson = AppContactPerson;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppContactPersonDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _AppContactPerson.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _AppContactPerson.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }