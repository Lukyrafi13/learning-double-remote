// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ArusKasMasuks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.ArusKasMasuks.Queries
// {
//     public class ArusKasMasuksGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<ArusKasMasukResponseDto>>>
//     {
//     }

//     public class GetFilterArusKasMasukQueryHandler : IRequestHandler<ArusKasMasuksGetFilterQuery, PagedResponse<IEnumerable<ArusKasMasukResponseDto>>>
//     {
//         private IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
//         private readonly IMapper _mapper;

//         public GetFilterArusKasMasukQueryHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
//         {
//             _ArusKasMasuk = ArusKasMasuk;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<ArusKasMasukResponseDto>>> Handle(ArusKasMasuksGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var data = await _ArusKasMasuk.GetPagedReponseAsync(request);
//             // var dataVm = _mapper.Map<IEnumerable<ArusKasMasukResponseDto>>(data.Results);
//             IEnumerable<ArusKasMasukResponseDto> dataVm;
//             var listResponse = new List<ArusKasMasukResponseDto>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<ArusKasMasukResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<ArusKasMasukResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }