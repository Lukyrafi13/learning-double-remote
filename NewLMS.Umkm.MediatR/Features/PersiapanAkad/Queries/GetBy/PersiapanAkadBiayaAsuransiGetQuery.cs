// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PersiapanAkads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.PersiapanAkads.Queries
// {
//     public class PersiapanAkadBiayaAsuransiGetQuery : PersiapanAkadFind, IRequest<ServiceResponse<PersiapanAkadBiayaAsuransiResponse>>
//     {
//     }

//     public class PersiapanAkadBiayaAsuransiGetQueryHandler : IRequestHandler<PersiapanAkadBiayaAsuransiGetQuery, ServiceResponse<PersiapanAkadBiayaAsuransiResponse>>
//     {
//         private IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
//         private IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public PersiapanAkadBiayaAsuransiGetQueryHandler(
//             IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
//             IGenericRepositoryAsync<Analisa> Analisa,
//             IMapper mapper)
//         {
//             _PersiapanAkad = PersiapanAkad;
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<PersiapanAkadBiayaAsuransiResponse>> Handle(PersiapanAkadBiayaAsuransiGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                 };

//                 var data = await _PersiapanAkad.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<PersiapanAkadBiayaAsuransiResponse>.Return404("Data PersiapanAkad not found");
                
                
//                 var existingAnalisa = await _Analisa.GetByIdAsync((Guid)data.AnalisaId, "Id");
                
//                 var response = _mapper.Map<PersiapanAkadBiayaAsuransiResponse>(data);
                
//                 response.NilaiProvisi = existingAnalisa.NilaiProvisi;
//                 response.NilaiPertanggungan = existingAnalisa.NilaiPertanggungan;
//                 response.BiayaAsuransi = existingAnalisa.TotalBiayaAsuransi;
//                 response.BiayaAdmin = existingAnalisa.BiayaAdmin;
                
//                 return ServiceResponse<PersiapanAkadBiayaAsuransiResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PersiapanAkadBiayaAsuransiResponse>.ReturnException(ex);
//             }
//         }
//     }
// }