using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRelationCols;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRelationCols.Commands
{
    public class RFRelationColDeleteCommand : RFRelationColFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFRelationColCommandHandler : IRequestHandler<RFRelationColDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFRelationCol> _RFRelationCol;
        private readonly IMapper _mapper;

        public DeleteRFRelationColCommandHandler(IGenericRepositoryAsync<RFRelationCol> RFRelationCol, IMapper mapper){
            _RFRelationCol = RFRelationCol;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFRelationColDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFRelationCol.GetByIdAsync(request.ReCode, "ReCode");
            rFProduct.IsDeleted = true;
            await _RFRelationCol.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}