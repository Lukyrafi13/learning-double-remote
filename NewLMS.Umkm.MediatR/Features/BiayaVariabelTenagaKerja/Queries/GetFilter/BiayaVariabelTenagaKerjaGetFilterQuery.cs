// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Queries
// {
//     public class BiayaVariabelTenagaKerjasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>>
//     {
//     }

//     public class GetFilterBiayaVariabelTenagaKerjaQueryHandler : IRequestHandler<BiayaVariabelTenagaKerjasGetFilterQuery, PagedResponse<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>>
//     {
//         private IGenericRepositoryAsync<BiayaVariabelTenagaKerja> _BiayaVariabelTenagaKerja;
//         private readonly IMapper _mapper;

//         public GetFilterBiayaVariabelTenagaKerjaQueryHandler(IGenericRepositoryAsync<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerja, IMapper mapper)
//         {
//             _BiayaVariabelTenagaKerja = BiayaVariabelTenagaKerja;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>> Handle(BiayaVariabelTenagaKerjasGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var data = await _BiayaVariabelTenagaKerja.GetPagedReponseAsync(request);
//             // var dataVm = _mapper.Map<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>(data.Results);
//             IEnumerable<BiayaVariabelTenagaKerjaResponseDto> dataVm;
//             var listResponse = new List<BiayaVariabelTenagaKerjaResponseDto>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<BiayaVariabelTenagaKerjaResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }