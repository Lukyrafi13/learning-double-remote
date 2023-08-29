// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Commands
// {
//     public class AnalisaAsuransiDeleteCommand : AnalisaAsuransiFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteAnalisaAsuransiCommandHandler : IRequestHandler<AnalisaAsuransiDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
//         private readonly IMapper _mapper;

//         public DeleteAnalisaAsuransiCommandHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper){
//             _AnalisaAsuransi = AnalisaAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AnalisaAsuransiDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _AnalisaAsuransi.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _AnalisaAsuransi.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }