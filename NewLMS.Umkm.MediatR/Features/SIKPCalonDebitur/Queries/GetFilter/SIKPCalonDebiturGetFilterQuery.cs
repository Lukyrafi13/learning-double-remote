// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SIKPCalonDebiturs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SIKPCalonDebiturs.Queries
// {
//     public class SIKPCalonDebitursGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPCalonDebiturResponseDto>>>
//     {
//     }

//     public class GetFilterSIKPCalonDebiturQueryHandler : IRequestHandler<SIKPCalonDebitursGetFilterQuery, PagedResponse<IEnumerable<SIKPCalonDebiturResponseDto>>>
//     {
//         private IGenericRepositoryAsync<SIKPCalonDebitur> _SIKPCalonDebitur;
//         private readonly IMapper _mapper;

//         public GetFilterSIKPCalonDebiturQueryHandler(IGenericRepositoryAsync<SIKPCalonDebitur> SIKPCalonDebitur, IMapper mapper)
//         {
//             _SIKPCalonDebitur = SIKPCalonDebitur;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<SIKPCalonDebiturResponseDto>>> Handle(SIKPCalonDebitursGetFilterQuery request, CancellationToken cancellationToken)
//         {
//                 var includes = new string[]{
//                     "App",
//                     "App.BookingOffice",
//                     "App.JenisProduk",
//                     // "App.Prospect",
//                     // "App.Prospect.SektorEkonomi",
//                     // "App.Prospect.SubSektorEkonomi",
//                     // "App.Prospect.SubSubSektorEkonomi",
//                     "TipeDebitur",
//                     "SektorEkonomi",
//                     "SubSektorEkonomi",
//                     "SubSubSektorEkonomi",
//                     "JenisKelamin",
//                     "StatusPernikahan",
//                     "PendidikanTerakhir",
//                     "DataPekerjaan",
//                     "KodePos",
//                     "KodePosUsaha",
//                     "Linkage",
//                     "JenisKelaminSIKP",
//                     "StatusPernikahanSIKP",
//                     "PendidikanTerakhirSIKP",
//                     "DataPekerjaanSIKP",
//                     "KodePosUsahaSIKP",
//                     "LinkageSIKP",
//                     "App.Prospect.ProspectStageLogs",
//                     "App.Prospect.ProspectStageLogs.RFStages",
//                 };

//             var data = await _SIKPCalonDebitur.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<SIKPCalonDebiturResponseDto>>(data.Results);
//             IEnumerable<SIKPCalonDebiturResponseDto> dataVm;
//             var listResponse = new List<SIKPCalonDebiturResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<SIKPCalonDebiturResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<SIKPCalonDebiturResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }