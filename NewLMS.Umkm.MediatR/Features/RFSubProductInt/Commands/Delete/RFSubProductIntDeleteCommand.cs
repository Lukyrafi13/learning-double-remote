using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSubProductInts;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSubProductInts.Commands
{
    public class RFSubProductIntDeleteCommand : RFSubProductIntFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSubProductIntCommandHandler : IRequestHandler<RFSubProductIntDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductInt> _RFSubProductInt;
        private readonly IMapper _mapper;

        public DeleteRFSubProductIntCommandHandler(IGenericRepositoryAsync<RFSubProductInt> RFSubProductInt, IMapper mapper){
            _RFSubProductInt = RFSubProductInt;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSubProductIntDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSubProductInt.GetByIdAsync(request.TPLCode, "TPLCode");
            rFProduct.IsDeleted = true;
            await _RFSubProductInt.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}