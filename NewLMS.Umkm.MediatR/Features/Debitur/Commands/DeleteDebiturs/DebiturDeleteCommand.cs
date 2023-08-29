// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Debiturs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Debiturs.Commands
// {
//     public class DebiturDeleteCommand : DebiturFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteDebiturCommandHandler : IRequestHandler<DebiturDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<Debitur> _debitur;
//         private readonly IMapper _mapper;

//         public DeleteDebiturCommandHandler(IGenericRepositoryAsync<Debitur> debitur, IMapper mapper){
//             _debitur = debitur;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(DebiturDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var Debitur = await _debitur.GetByIdAsync(request.Id, "Id");
//             Debitur.IsDeleted = true;
//             await _debitur.UpdateAsync(Debitur);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }