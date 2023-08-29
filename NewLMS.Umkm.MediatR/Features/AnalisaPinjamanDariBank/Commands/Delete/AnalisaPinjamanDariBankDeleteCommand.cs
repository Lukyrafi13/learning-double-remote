// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaPinjamanDariBanks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaPinjamanDariBanks.Commands
// {
//     public class AnalisaPinjamanDariBankDeleteCommand : AnalisaPinjamanDariBankFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteAnalisaPinjamanDariBankCommandHandler : IRequestHandler<AnalisaPinjamanDariBankDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
//         private readonly IMapper _mapper;

//         public DeleteAnalisaPinjamanDariBankCommandHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper){
//             _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AnalisaPinjamanDariBankDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _AnalisaPinjamanDariBank.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _AnalisaPinjamanDariBank.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }