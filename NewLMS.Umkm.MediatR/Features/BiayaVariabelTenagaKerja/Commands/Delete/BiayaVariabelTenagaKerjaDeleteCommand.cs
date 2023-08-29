// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Commands
// {
//     public class BiayaVariabelTenagaKerjaDeleteCommand : BiayaVariabelTenagaKerjaFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteBiayaVariabelTenagaKerjaCommandHandler : IRequestHandler<BiayaVariabelTenagaKerjaDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaVariabelTenagaKerja> _BiayaVariabelTenagaKerja;
//         private readonly IMapper _mapper;

//         public DeleteBiayaVariabelTenagaKerjaCommandHandler(IGenericRepositoryAsync<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerja, IMapper mapper)
//         {
//             _BiayaVariabelTenagaKerja = BiayaVariabelTenagaKerja;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(BiayaVariabelTenagaKerjaDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _BiayaVariabelTenagaKerja.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _BiayaVariabelTenagaKerja.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }