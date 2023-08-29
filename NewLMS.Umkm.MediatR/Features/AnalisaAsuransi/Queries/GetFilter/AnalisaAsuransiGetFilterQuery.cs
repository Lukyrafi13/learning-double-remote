// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Queries
// {
//     public class AnalisaAsuransisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>>
//     {
//     }

//     public class GetFilterAnalisaAsuransiQueryHandler : IRequestHandler<AnalisaAsuransisGetFilterQuery, PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
//         private readonly IMapper _mapper;

//         public GetFilterAnalisaAsuransiQueryHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper)
//         {
//             _AnalisaAsuransi = AnalisaAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>> Handle(AnalisaAsuransisGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "Analisa",
//                     "Analisa.Survey",
//                     "RFJenisAsuransi",
//                 };

//             var data = await _AnalisaAsuransi.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AnalisaAsuransiResponseDto>>(data.Results);
//             IEnumerable<AnalisaAsuransiResponseDto> dataVm;
//             var listResponse = new List<AnalisaAsuransiResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AnalisaAsuransiResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }