using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyFileUploads;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveyFileUploads.Commands
{
    public class SurveyFileUploadDeleteCommand : SurveyFileUploadFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSurveyFileUploadCommandHandler : IRequestHandler<SurveyFileUploadDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SurveyFileUpload> _SurveyFileUpload;
        private readonly IMapper _mapper;

        public DeleteSurveyFileUploadCommandHandler(IGenericRepositoryAsync<SurveyFileUpload> SurveyFileUpload, IMapper mapper){
            _SurveyFileUpload = SurveyFileUpload;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SurveyFileUploadDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SurveyFileUpload.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SurveyFileUpload.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}