// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppFasilitasKredits;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppFasilitasKredits.Commands
// {
//     public class AppFasilitasKreditPutCommand : AppFasilitasKreditPutRequestDto, IRequest<ServiceResponse<AppFasilitasKreditResponseDto>>
//     {
//     }

//     public class PutAppFasilitasKreditCommandHandler : IRequestHandler<AppFasilitasKreditPutCommand, ServiceResponse<AppFasilitasKreditResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
//         private readonly IMapper _mapper;

//         public PutAppFasilitasKreditCommandHandler(IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit, IMapper mapper)
//         {
//             _AppFasilitasKredit = AppFasilitasKredit;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppFasilitasKreditResponseDto>> Handle(AppFasilitasKreditPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAppFasilitasKredit = await _AppFasilitasKredit.GetByIdAsync(request.Id, "Id");
                
//                 existingAppFasilitasKredit.PlafondYangDiajukan = request.PlafondYangDiajukan;
//                 existingAppFasilitasKredit.TujuanPenggunaan = request.TujuanPenggunaan;
//                 existingAppFasilitasKredit.TipeCicilan = request.TipeCicilan;
//                 existingAppFasilitasKredit.TingkatSukuBunga = request.TingkatSukuBunga;
//                 existingAppFasilitasKredit.AngsuranPokok = request.AngsuranPokok;
//                 existingAppFasilitasKredit.AngsuranBunga = request.AngsuranBunga;
//                 existingAppFasilitasKredit.AppId = request.AppId;
//                 existingAppFasilitasKredit.RfAppTypeKreditId = request.RfAppTypeKreditId;
//                 existingAppFasilitasKredit.RFLoanPurposeId = request.RFLoanPurposeId;
//                 existingAppFasilitasKredit.RFSubProductId = request.RFSubProductId;
//                 existingAppFasilitasKredit.RFNegaraPenempatanId = request.RFNegaraPenempatanId;
//                 existingAppFasilitasKredit.RFTenorId = request.RFTenorId;
//                 existingAppFasilitasKredit.RFSifatKreditId = request.RFSifatKreditId;
//                 existingAppFasilitasKredit.RfSectorLBU1Code = request.RfSectorLBU1Code;
//                 existingAppFasilitasKredit.RfSectorLBU2Code = request.RfSectorLBU2Code;
//                 existingAppFasilitasKredit.RfSectorLBU3Code = request.RfSectorLBU3Code;

//                 await _AppFasilitasKredit.UpdateAsync(existingAppFasilitasKredit);

//                 var response = _mapper.Map<AppFasilitasKreditResponseDto>(existingAppFasilitasKredit);

//                 return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppFasilitasKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }