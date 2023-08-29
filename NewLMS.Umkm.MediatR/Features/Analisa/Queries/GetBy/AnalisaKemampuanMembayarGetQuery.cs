// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using Org.BouncyCastle.Math.EC.Rfc7748;
// using System.Linq;

// namespace NewLMS.UMKM.MediatR.Features.Analisas.Queries
// {
//     public class AnalisaKemampuanMembayarGetQuery : AnalisaFind, IRequest<ServiceResponse<AnalisaKemampuanMembayarResponse>>
//     {
//     }

//     public class AnalisaKemampuanMembayarGetQueryHandler : IRequestHandler<AnalisaKemampuanMembayarGetQuery, ServiceResponse<AnalisaKemampuanMembayarResponse>>
//     {
//         private IGenericRepositoryAsync<Analisa> _Analisa;
//         private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
//         private IGenericRepositoryAsync<AppFasilitasKredit> _AppFasilitasKredit;
//         private IGenericRepositoryAsync<AnalisaFasilitas> _AnalisaFasilitas;
//         private readonly IMapper _mapper;

//         public AnalisaKemampuanMembayarGetQueryHandler(
//             IGenericRepositoryAsync<Analisa> Analisa,
//             IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank,
//             IGenericRepositoryAsync<AppFasilitasKredit> AppFasilitasKredit,
//             IGenericRepositoryAsync<AnalisaFasilitas> AnalisaFasilitas,
//             IMapper mapper)
//         {
//             _Analisa = Analisa;
//             _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
//             _AppFasilitasKredit = AppFasilitasKredit;
//             _AnalisaFasilitas = AnalisaFasilitas;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AnalisaKemampuanMembayarResponse>> Handle(AnalisaKemampuanMembayarGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "Survey"
//                 };

//                 var data = await _Analisa.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AnalisaKemampuanMembayarResponse>.Return404("Data Analisa not found");
//                 var response = _mapper.Map<AnalisaKemampuanMembayarResponse>(data);

//                 // Calculate read-only values
//                 double totalAngsuran = 0;
//                 double rekomendasiAngsuran = 0;

//                 // Calculate total angsuran
//                 var listPinjamanLain = await _AnalisaPinjamanDariBank.GetListByPredicate(x => x.AnalisaId == data.Id);

//                 foreach (var pinjaman in listPinjamanLain)
//                 {
//                     if (!(pinjaman.FasilitasTakeOver??false)){
//                         totalAngsuran += pinjaman.Angsuran??0;
//                     }
//                 }

//                 // Calculate rekomendasi angsuran
//                 var listFasilitasKredit = await _AppFasilitasKredit.GetListByPredicate(x => x.AppId == data.AppId);
//                 var listFasilitasAnalisa = await _AnalisaFasilitas.GetListByPredicate(x => x.Analisa.AppId == data.AppId,
//                 new string[]{
//                     "Analisa"
//                 });

//                 foreach (var fasilitas in listFasilitasKredit){
//                     var analisaFasilitas = listFasilitasAnalisa.FirstOrDefault(x=>x.AppFasilitasKreditId == fasilitas.Id);
//                     rekomendasiAngsuran += analisaFasilitas?.Angsuran??fasilitas.Angsuran;
//                 }

//                 response.TotalAngsuranPinjaman = totalAngsuran;
//                 response.RekomendasiAngsuran = rekomendasiAngsuran;
//                 response.DisposableIncome = response.SisaPenghasilan - response.TotalAngsuranPinjaman - response.RekomendasiAngsuran;
//                 response.IDIR = (response.TotalAngsuranPinjaman + response.RekomendasiAngsuran) / response.DisposableIncome * 100;
                
                
//                 return ServiceResponse<AnalisaKemampuanMembayarResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaKemampuanMembayarResponse>.ReturnException(ex);
//             }
//         }
//     }
// }