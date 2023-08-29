// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaInvestasis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.BiayaInvestasis.Queries
// {
//     public class BiayaInvestasisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<BiayaInvestasiResponseDto>>>
//     {
//     }

//     public class GetFilterBiayaInvestasiQueryHandler : IRequestHandler<BiayaInvestasisGetFilterQuery, PagedResponse<IEnumerable<BiayaInvestasiResponseDto>>>
//     {
//         private IGenericRepositoryAsync<BiayaInvestasi> _BiayaInvestasi;
//         private readonly IMapper _mapper;

//         public GetFilterBiayaInvestasiQueryHandler(IGenericRepositoryAsync<BiayaInvestasi> BiayaInvestasi, IMapper mapper)
//         {
//             _BiayaInvestasi = BiayaInvestasi;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<BiayaInvestasiResponseDto>>> Handle(BiayaInvestasisGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var data = await _BiayaInvestasi.GetPagedReponseAsync(request);
//             // var dataVm = _mapper.Map<IEnumerable<BiayaInvestasiResponseDto>>(data.Results);
//             IEnumerable<BiayaInvestasiResponseDto> dataVm;
//             var listResponse = new List<BiayaInvestasiResponseDto>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<BiayaInvestasiResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<BiayaInvestasiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }