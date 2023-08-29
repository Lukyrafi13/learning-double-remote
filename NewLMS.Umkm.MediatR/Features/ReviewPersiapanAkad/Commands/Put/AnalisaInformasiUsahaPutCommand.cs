// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.Analisas;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Helper;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.Umkm.MediatR.Features.Analisas.Commands
// {
//     public class AnalisaInformasiUsahaPutCommand : AnalisaInformasiUsahaPut, IRequest<ServiceResponse<AnalisaInformasiUsahaResponse>>
//     {
//     }

//     public class AnalisaInformasiUsahaPutCommandHandler : IRequestHandler<AnalisaInformasiUsahaPutCommand, ServiceResponse<AnalisaInformasiUsahaResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public AnalisaInformasiUsahaPutCommandHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaInformasiUsahaResponse>> Handle(AnalisaInformasiUsahaPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
//                 existingAnalisa.AlamatUsahaSamaDenganAplikasi = request.AlamatUsahaSamaDenganAplikasi;
//                 existingAnalisa.JarakLokasiUsahaDariCabang = request.JarakLokasiUsahaDariCabang;
//                 existingAnalisa.PerijinanYangDimiliki = request.PerijinanYangDimiliki;
//                 existingAnalisa.Nomor = request.Nomor;
//                 existingAnalisa.RACMemilikiUsaha = request.RACMemilikiUsaha;
//                 existingAnalisa.LamaUsaha = request.LamaUsaha;
//                 existingAnalisa.LamaMenempatiTempatUsaha = request.LamaMenempatiTempatUsaha;
//                 existingAnalisa.MemilikiUsahaLain = request.MemilikiUsahaLain;
//                 existingAnalisa.UsahaTidakTermasukJenisDihindari = request.UsahaTidakTermasukJenisDihindari;
//                 existingAnalisa.AktifitasUsaha = request.AktifitasUsaha;
//                 existingAnalisa.AppId = request.AppId;
//                 existingAnalisa.PrescreeningId = request.PrescreeningId;
//                 existingAnalisa.SurveyId = request.SurveyId;
//                 existingAnalisa.RFLokasiUsahaId = request.RFLokasiUsahaId;
//                 existingAnalisa.RFJenisTempatUsahaId = request.RFJenisTempatUsahaId;
//                 existingAnalisa.RFKelompokUsahaId = request.RFKelompokUsahaId;
//                 existingAnalisa.RFJenisUsahaId = request.RFJenisUsahaId;
//                 existingAnalisa.RFLokasiTempatUsahaId = request.RFLokasiTempatUsahaId;
//                 existingAnalisa.RFBuktiKepemilikanId = request.RFBuktiKepemilikanId;
//                 existingAnalisa.RFAspekPemasaranId = request.RFAspekPemasaranId;
//                 existingAnalisa.RFJumlahPegawaiTetapId = request.RFJumlahPegawaiTetapId;
//                 existingAnalisa.RFJumlahPegawaiHarianId = request.RFJumlahPegawaiHarianId;

//                 await _Analisa.UpdateAsync(existingAnalisa);

//                 var response = _mapper.Map<AnalisaInformasiUsahaResponse>(existingAnalisa);

//                 return ServiceResponse<AnalisaInformasiUsahaResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaInformasiUsahaResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }