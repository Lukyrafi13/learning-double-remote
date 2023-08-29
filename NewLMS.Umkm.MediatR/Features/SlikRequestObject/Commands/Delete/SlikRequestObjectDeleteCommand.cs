// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequestObjects;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Commands
// {
//     public class SlikRequestObjectDeleteCommand : SlikRequestObjectFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteSlikRequestObjectCommandHandler : IRequestHandler<SlikRequestObjectDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
//         private readonly IMapper _mapper;

//         public DeleteSlikRequestObjectCommandHandler(IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject, IMapper mapper){
//             _SlikRequestObject = SlikRequestObject;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(SlikRequestObjectDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _SlikRequestObject.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _SlikRequestObject.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }