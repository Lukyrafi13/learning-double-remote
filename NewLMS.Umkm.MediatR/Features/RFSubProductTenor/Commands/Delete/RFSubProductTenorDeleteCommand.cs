using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Commands
{
    public class RFSubProductTenorDeleteCommand : RFSubProductTenorFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFSubProductTenorCommandHandler : IRequestHandler<RFSubProductTenorDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFSubProductTenor> _RFSubProductTenor;
        private readonly IMapper _mapper;

        public DeleteRFSubProductTenorCommandHandler(IGenericRepositoryAsync<RFSubProductTenor> RFSubProductTenor, IMapper mapper){
            _RFSubProductTenor = RFSubProductTenor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFSubProductTenorDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFSubProductTenor.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _RFSubProductTenor.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}