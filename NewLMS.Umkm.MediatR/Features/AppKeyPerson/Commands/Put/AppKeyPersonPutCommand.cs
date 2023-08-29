// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppKeyPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppKeyPersons.Commands
// {
//     public class AppKeyPersonPutCommand : AppKeyPersonPutRequestDto, IRequest<ServiceResponse<AppKeyPersonResponseDto>>
//     {
//     }

//     public class PutAppKeyPersonCommandHandler : IRequestHandler<AppKeyPersonPutCommand, ServiceResponse<AppKeyPersonResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IMapper _mapper;

//         public PutAppKeyPersonCommandHandler(IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson, IMapper mapper)
//         {
//             _AppKeyPerson = AppKeyPerson;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppKeyPersonResponseDto>> Handle(AppKeyPersonPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAppKeyPerson = await _AppKeyPerson.GetByIdAsync(request.Id, "Id");
//                 existingAppKeyPerson.AppId = request.AppId;
//                 existingAppKeyPerson.Nama = request.Nama;
//                 existingAppKeyPerson.TempatLahir = request.TempatLahir;
//                 existingAppKeyPerson.TanggalLahir = request.TanggalLahir;
//                 existingAppKeyPerson.Jabatan = request.Jabatan;
//                 existingAppKeyPerson.NoKTP = request.NoKTP;
//                 existingAppKeyPerson.NomorTelpon = request.NomorTelpon;
//                 existingAppKeyPerson.MasaBerlakuKTP = request.MasaBerlakuKTP;
//                 existingAppKeyPerson.SeumurHidup = request.SeumurHidup;
//                 existingAppKeyPerson.NPWP = request.NPWP;
//                 existingAppKeyPerson.RFEducationId = request.RFEducationId;
//                 existingAppKeyPerson.RFMaritalId = request.RFMaritalId;
//                 existingAppKeyPerson.Alamat = request.Alamat;
//                 existingAppKeyPerson.RfZipCodeId = request.RfZipCodeId;
//                 existingAppKeyPerson.Kelurahan = request.Kelurahan;
//                 existingAppKeyPerson.Kecamatan = request.Kecamatan;
//                 existingAppKeyPerson.KabupatenKota = request.KabupatenKota;
//                 existingAppKeyPerson.Propinsi = request.Propinsi;

//                 await _AppKeyPerson.UpdateAsync(existingAppKeyPerson);

//                 var response = _mapper.Map<AppKeyPersonResponseDto>(existingAppKeyPerson);

//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }