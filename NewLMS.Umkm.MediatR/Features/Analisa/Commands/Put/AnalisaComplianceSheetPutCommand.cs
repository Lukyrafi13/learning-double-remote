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
//     public class AnalisaComplianceSheetPutCommand : AnalisaComplianceSheetPut, IRequest<ServiceResponse<AnalisaHubunganBankResponse>>
//     {
//     }

//     public class AnalisaComplianceSheetPutCommandHandler : IRequestHandler<AnalisaComplianceSheetPutCommand, ServiceResponse<AnalisaHubunganBankResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaComplianceSheetPutCommandHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaHubunganBankResponse>> Handle(AnalisaComplianceSheetPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 existingAnalisa = _mapper.Map<AnalisaComplianceSheetPut, Analisa>(request, existingAnalisa);

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