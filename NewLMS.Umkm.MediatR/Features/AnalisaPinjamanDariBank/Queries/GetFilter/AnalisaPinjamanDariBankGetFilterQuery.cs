// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaPinjamanDariBanks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaPinjamanDariBanks.Queries
// {
//     public class AnalisaPinjamanDariBanksGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AnalisaPinjamanDariBankResponseDto>>>
//     {
//     }

//     public class GetFilterAnalisaPinjamanDariBankQueryHandler : IRequestHandler<AnalisaPinjamanDariBanksGetFilterQuery, PagedResponse<IEnumerable<AnalisaPinjamanDariBankResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AnalisaPinjamanDariBank> _AnalisaPinjamanDariBank;
//         private readonly IMapper _mapper;

//         public GetFilterAnalisaPinjamanDariBankQueryHandler(IGenericRepositoryAsync<AnalisaPinjamanDariBank> AnalisaPinjamanDariBank, IMapper mapper)
//         {
//             _AnalisaPinjamanDariBank = AnalisaPinjamanDariBank;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AnalisaPinjamanDariBankResponseDto>>> Handle(AnalisaPinjamanDariBanksGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "Analisa",
//                     "Analisa.Survey",
//                     "TujuanPinjaman",
//                 };

//             var data = await _AnalisaPinjamanDariBank.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AnalisaPinjamanDariBankResponseDto>>(data.Results);
//             IEnumerable<AnalisaPinjamanDariBankResponseDto> dataVm;
//             var listResponse = new List<AnalisaPinjamanDariBankResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AnalisaPinjamanDariBankResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AnalisaPinjamanDariBankResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }