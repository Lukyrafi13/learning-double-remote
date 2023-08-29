// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PrescreeningDokumens;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Collections.Generic;

// namespace NewLMS.UMKM.MediatR.Features.PrescreeningDokumens.Queries
// {
//     public class PrescreeningDokumenGetQuery : PrescreeningDokumenFindRequestDto, IRequest<ServiceResponse<PrescreeningDokumenResponseDto>>
//     {
//     }

//     public class PrescreeningDokumenGetQueryHandler : IRequestHandler<PrescreeningDokumenGetQuery, ServiceResponse<PrescreeningDokumenResponseDto>>
//     {
//         private IGenericRepositoryAsync<PrescreeningDokumen> _PrescreeningDokumen;
//         private IGenericRepositoryAsync<FileDokumen> _FileDokumen;
//         private readonly IMapper _mapper;

//         public PrescreeningDokumenGetQueryHandler(
//             IGenericRepositoryAsync<PrescreeningDokumen> PrescreeningDokumen,
//             IGenericRepositoryAsync<FileDokumen> FileDokumen,
//             IMapper mapper)
//         {
//             _PrescreeningDokumen = PrescreeningDokumen;
//             _FileDokumen = FileDokumen;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<PrescreeningDokumenResponseDto>> Handle(PrescreeningDokumenGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "Prescreening",
//                     "Dokumen",
//                     "TipeDokumen",
//                     "DokumenStatus",
//                     "JenisAgunan",
//                 };

//                 var data = await _PrescreeningDokumen.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<PrescreeningDokumenResponseDto>.Return404("Data PrescreeningDokumen not found");
//                 var response = _mapper.Map<PrescreeningDokumenResponseDto>(data);

//                 var fileDokumens = await _FileDokumen.GetListByPredicate(x => x.PrescreeningDokumenId == data.Id, new string[] { "FileUrl"});
//                 var listFileDokumens = new List<FileDokumen>();

//                 foreach (var fileDokumen in fileDokumens){
//                     listFileDokumens.Add(fileDokumen);
//                 }

//                 response.ListFile = listFileDokumens;

//                 return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PrescreeningDokumenResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }