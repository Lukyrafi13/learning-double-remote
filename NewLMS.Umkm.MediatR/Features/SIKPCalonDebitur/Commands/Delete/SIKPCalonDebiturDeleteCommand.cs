// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SIKPCalonDebiturs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SIKPCalonDebiturs.Commands
// {
//     public class SIKPCalonDebiturDeleteCommand : SIKPCalonDebiturFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteSIKPCalonDebiturCommandHandler : IRequestHandler<SIKPCalonDebiturDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
//         private readonly IMapper _mapper;

//         public DeleteSIKPCalonDebiturCommandHandler(IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur, IMapper mapper){
//             _SIKPCalonDebitur = SIKPCalonDebitur;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(SIKPCalonDebiturDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _SIKPCalonDebitur.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _SIKPCalonDebitur.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }