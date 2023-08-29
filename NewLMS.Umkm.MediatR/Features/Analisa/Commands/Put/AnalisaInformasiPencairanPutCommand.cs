// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaInformasiPencairanPutCommand : AnalisaInformasiPencairanPut, IRequest<ServiceResponse<AnalisaInformasiPencairanResponse>>
//     {
//     }

//     public class AnalisaInformasiPencairanPutCommandHandler : IRequestHandler<AnalisaInformasiPencairanPutCommand, ServiceResponse<AnalisaInformasiPencairanResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaInformasiPencairanPutCommandHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaInformasiPencairanResponse>> Handle(AnalisaInformasiPencairanPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 var updatedAnalisa = _mapper.Map<AnalisaInformasiPencairanPut, Analisa>(request, existingAnalisa);

//                 await _Analisa.UpdateAsync(existingAnalisa);

//                 var response = _mapper.Map<AnalisaInformasiPencairanResponse>(existingAnalisa);

//                 return ServiceResponse<AnalisaInformasiPencairanResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaInformasiPencairanResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }