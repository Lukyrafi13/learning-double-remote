// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PersiapanAkads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.PersiapanAkads.Commands
// {
//     public class PersiapanAkadBiayaAsuransiPutCommand : PersiapanAkadBiayaAsuransiPut, IRequest<ServiceResponse<PersiapanAkadBiayaAsuransiResponse>>
//     {
//     }

//     public class PersiapanAkadBiayaAsuransiPutCommandHandler : IRequestHandler<PersiapanAkadBiayaAsuransiPutCommand, ServiceResponse<PersiapanAkadBiayaAsuransiResponse>>
//     {
//         private readonly IGenericRepositoryAsync<PersiapanAkad> _PersiapanAkad;
//         private readonly IGenericRepositoryAsync<Analisa> _Analisa;
//         private readonly IMapper _mapper;

//         public PersiapanAkadBiayaAsuransiPutCommandHandler(
//             IGenericRepositoryAsync<PersiapanAkad> PersiapanAkad,
//             IGenericRepositoryAsync<Analisa> Analisa,
//             IMapper mapper)
//         {
//             _PersiapanAkad = PersiapanAkad;
//             _Analisa = Analisa;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PersiapanAkadBiayaAsuransiResponse>> Handle(PersiapanAkadBiayaAsuransiPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingPersiapanAkad = await _PersiapanAkad.GetByIdAsync(request.Id, "Id");
                
//                 existingPersiapanAkad = _mapper.Map<PersiapanAkadBiayaAsuransiPut, PersiapanAkad>(request, existingPersiapanAkad);

//                 await _PersiapanAkad.UpdateAsync(existingPersiapanAkad);

//                 var existingAnalisa = await _Analisa.GetByIdAsync((Guid)existingPersiapanAkad.AnalisaId, "Id");
                
//                 existingAnalisa.Provisi = request.Provisi;

//                 await _Analisa.UpdateAsync(existingAnalisa);

//                 var response = _mapper.Map<PersiapanAkadBiayaAsuransiResponse>(existingPersiapanAkad);

//                 response.NilaiProvisi = existingAnalisa.NilaiProvisi;
//                 response.NilaiPertanggungan = existingAnalisa.NilaiPertanggungan;
//                 response.BiayaAsuransi = existingAnalisa.TotalBiayaAsuransi;
//                 response.BiayaAdmin = existingAnalisa.BiayaAdmin;

//                 return ServiceResponse<PersiapanAkadBiayaAsuransiResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PersiapanAkadBiayaAsuransiResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }