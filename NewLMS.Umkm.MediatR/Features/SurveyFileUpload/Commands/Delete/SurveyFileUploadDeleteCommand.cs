// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SurveyFileUploads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SurveyFileUploads.Commands
// {
//     public class SurveyFileUploadDeleteCommand : SurveyFileUploadFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteSurveyFileUploadCommandHandler : IRequestHandler<SurveyFileUploadDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<SurveyFileUpload> _SurveyFileUpload;
//         private readonly IMapper _mapper;

//         public DeleteSurveyFileUploadCommandHandler(IGenericRepositoryAsync<SurveyFileUpload> SurveyFileUpload, IMapper mapper){
//             _SurveyFileUpload = SurveyFileUpload;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(SurveyFileUploadDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _SurveyFileUpload.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _SurveyFileUpload.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }