using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingPrescreeningDocuments;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMappingPrescreeningDocuments.Commands
{
    public class RFMappingPrescreeningDocumentDeleteCommand : RFMappingPrescreeningDocumentFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFMappingPrescreeningDocumentCommandHandler : IRequestHandler<RFMappingPrescreeningDocumentDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFMappingPrescreeningDocument> _RFMappingPrescreeningDocument;
        private readonly IMapper _mapper;

        public DeleteRFMappingPrescreeningDocumentCommandHandler(IGenericRepositoryAsync<RFMappingPrescreeningDocument> RFMappingPrescreeningDocument, IMapper mapper){
            _RFMappingPrescreeningDocument = RFMappingPrescreeningDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFMappingPrescreeningDocumentDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFMappingPrescreeningDocument.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFMappingPrescreeningDocument.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}