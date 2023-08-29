using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDocumentAgunans.Commands
{
    public class RFDocumentAgunanDeleteCommand : RFDocumentAgunanFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFDocumentAgunanCommandHandler : IRequestHandler<RFDocumentAgunanDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IMapper _mapper;

        public DeleteRFDocumentAgunanCommandHandler(IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan, IMapper mapper){
            _RFDocumentAgunan = RFDocumentAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFDocumentAgunanDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFDocumentAgunan.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFDocumentAgunan.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}