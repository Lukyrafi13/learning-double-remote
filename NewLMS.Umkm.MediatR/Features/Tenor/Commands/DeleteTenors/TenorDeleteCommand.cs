// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Tenors;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Tenors.Commands
// {
//     public class TenorDeleteCommand : TenorFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteTenorCommandHandler : IRequestHandler<TenorDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<Tenor> _Tenor;
//         private readonly IMapper _mapper;

//         public DeleteTenorCommandHandler(IGenericRepositoryAsync<Tenor> Tenor, IMapper mapper){
//             _Tenor = Tenor;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(TenorDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _Tenor.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
//             rFProduct.IsDeleted = true;
//             await _Tenor.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }