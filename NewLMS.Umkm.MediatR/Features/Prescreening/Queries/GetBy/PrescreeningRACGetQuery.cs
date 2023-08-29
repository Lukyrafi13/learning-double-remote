// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Prescreenings;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.Prescreenings.Queries
// {
//     public class PrescreeningRACGetQuery : PrescreeningFind, IRequest<ServiceResponse<PrescreeningRACResponse>>
//     {
//     }

//     public class PrescreeningRACGetQueryHandler : IRequestHandler<PrescreeningRACGetQuery, ServiceResponse<PrescreeningRACResponse>>
//     {
//         private IGenericRepositoryAsync<Prescreening> _Prescreening;
//         private readonly IMapper _mapper;

//         public PrescreeningRACGetQueryHandler(IGenericRepositoryAsync<Prescreening> Prescreening, IMapper mapper)
//         {
//             _Prescreening = Prescreening;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<PrescreeningRACResponse>> Handle(PrescreeningRACGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                 };

//                 var data = await _Prescreening.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<PrescreeningRACResponse>.Return404("Data Prescreening not found");
//                 var response = _mapper.Map<PrescreeningRACResponse>(data);
//                 return ServiceResponse<PrescreeningRACResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PrescreeningRACResponse>.ReturnException(ex);
//             }
//         }
//     }
// }