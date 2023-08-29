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
//     public class AnalisaHubunganBankPutCommand : AnalisaHubunganBankPut, IRequest<ServiceResponse<AnalisaHubunganBankResponse>>
//     {
//     }

//     public class AnalisaHubunganBankPutCommandHandler : IRequestHandler<AnalisaHubunganBankPutCommand, ServiceResponse<AnalisaHubunganBankResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaHubunganBankPutCommandHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaHubunganBankResponse>> Handle(AnalisaHubunganBankPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 existingAnalisa.DPD3BulanTerakhir = request.DPD3BulanTerakhir;
//                 existingAnalisa.AlasanKeterlambatan = request.AlasanKeterlambatan;

//                 await _Analisa.UpdateAsync(existingAnalisa);

//                 var response = _mapper.Map<AnalisaHubunganBankResponse>(existingAnalisa);

//                 return ServiceResponse<AnalisaHubunganBankResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaHubunganBankResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }