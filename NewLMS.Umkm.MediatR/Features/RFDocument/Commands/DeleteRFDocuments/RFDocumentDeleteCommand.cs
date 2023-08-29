using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocuments;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDocuments.Commands
{
    public class RFDocumentDeleteCommand : RFDocumentFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFDocumentCommandHandler : IRequestHandler<RFDocumentDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IMapper _mapper;

        public DeleteRFDocumentCommandHandler(IGenericRepositoryAsync<RFDocument> RFDocument, IMapper mapper){
            _RFDocument = RFDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFDocumentDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFDocument.GetByIdAsync(request.DocCode, "DocCode");
            rFProduct.IsDeleted = true;
            await _RFDocument.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}