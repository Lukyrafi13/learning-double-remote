// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaSyaratKredits;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaSyaratKredits.Queries
// {
//     public class AnalisaSyaratKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaSyaratKreditResponseDto>>>
//     {
//     }

//     public class GetFilterAnalisaSyaratKreditQueryHandler : IRequestHandler<AnalisaSyaratKreditsGetFilterQuery, PagedResponse<IEnumerable<AnalisaSyaratKreditResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AnalisaSyaratKredit> _AnalisaSyaratKredit;
//         private readonly IMapper _mapper;

//         public GetFilterAnalisaSyaratKreditQueryHandler(IGenericRepositoryAsync<AnalisaSyaratKredit> AnalisaSyaratKredit, IMapper mapper)
//         {
//             _AnalisaSyaratKredit = AnalisaSyaratKredit;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AnalisaSyaratKreditResponseDto>>> Handle(AnalisaSyaratKreditsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "Analisa",
//                     "Analisa.Survey",
//                     "JenisSyaratKredit",
//                     "Decision",
//                 };

//             var data = await _AnalisaSyaratKredit.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AnalisaSyaratKreditResponseDto>>(data.Results);
//             IEnumerable<AnalisaSyaratKreditResponseDto> dataVm;
//             var listResponse = new List<AnalisaSyaratKreditResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AnalisaSyaratKreditResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AnalisaSyaratKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }