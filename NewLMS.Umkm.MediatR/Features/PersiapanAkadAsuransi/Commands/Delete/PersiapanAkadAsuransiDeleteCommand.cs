// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PersiapanAkadAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.PersiapanAkadAsuransis.Commands
// {
//     public class PersiapanAkadAsuransiDeleteCommand : PersiapanAkadAsuransiFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeletePersiapanAkadAsuransiCommandHandler : IRequestHandler<PersiapanAkadAsuransiDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
//         private readonly IMapper _mapper;

//         public DeletePersiapanAkadAsuransiCommandHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper){
//             _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(PersiapanAkadAsuransiDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _PersiapanAkadAsuransi.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _PersiapanAkadAsuransi.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }