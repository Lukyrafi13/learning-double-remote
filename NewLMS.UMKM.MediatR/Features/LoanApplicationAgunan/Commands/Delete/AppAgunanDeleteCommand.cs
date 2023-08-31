// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppAgunans;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppAgunans.Commands
// {
//     public class AppAgunanDeleteCommand : AppAgunanFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteAppAgunanCommandHandler : IRequestHandler<AppAgunanDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<AppAgunan> _AppAgunan;
//         private readonly IMapper _mapper;

//         public DeleteAppAgunanCommandHandler(IGenericRepositoryAsync<AppAgunan> AppAgunan, IMapper mapper){
//             _AppAgunan = AppAgunan;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AppAgunanDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _AppAgunan.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _AppAgunan.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }